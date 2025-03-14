using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfSocialLinkDal : EfEntityRepositoryBase<SocialLink, PortfContext>, ISocialLinkDal 
    {
        public bool UpdateSocialLink(socialLinkDto socialLinkDto)
        {
            using (PortfContext context = new PortfContext())
            {
                var existingSocialLinks = context.SocialLinks
                    .Where(s => s.UserId == socialLinkDto.UserId)
                    .ToList();



                var existingSocialLinksIds = existingSocialLinks.Select(s => s.SocialLinkId).ToHashSet();
                var incomingSocialLinks = socialLinkDto.socialLinks.Select(s => s.SocialLinkId).ToHashSet();



                foreach (var existingSocialLink in existingSocialLinks)
                {
                    var updatedSocialLink = socialLinkDto.socialLinks
                        .FirstOrDefault(s => s.SocialLinkId == existingSocialLink.SocialLinkId);

                    if (updatedSocialLink != null)
                    {
                        existingSocialLink.Platform = updatedSocialLink.Platform;
                        existingSocialLink.Url = updatedSocialLink.Url;
                        existingSocialLink.UserId = updatedSocialLink.UserId;
                        context.Entry(existingSocialLink).State = EntityState.Modified;
                    }
                }


                var newsocialLink = socialLinkDto.socialLinks
                    .Where(socialLink => !existingSocialLinksIds.Contains(socialLink.SocialLinkId))
                    .Select(socialLink => new SocialLink
                    {
                        SocialLinkId = socialLink.SocialLinkId,
                        Url = socialLink.Url,
                        Platform = socialLink.Platform,
                        UserId = socialLinkDto.UserId,

                    })
                    .ToList();

                if (newsocialLink.Any())
                {
                    context.SocialLinks.AddRange(newsocialLink);
                }

                context.SaveChanges();

                return true;
            }
        }
    }
}
