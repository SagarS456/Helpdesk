﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Helpdesk.Models.Configuration
{
    public class AttachmentConfiguration : EntityTypeConfiguration<Attachment>
    {
        public AttachmentConfiguration()
        {
            HasKey(x => x.Id);

            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.FileName)
                .IsRequired()
                .HasMaxLength(255);

            HasRequired(i => i.Issue)
            .WithMany(a => a.Attachments)
            .HasForeignKey(i => i.IssueId)
            .WillCascadeOnDelete(false);
        }
    }
}