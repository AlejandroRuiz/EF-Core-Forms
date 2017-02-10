﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using EF.Forms.Data;

namespace EF.Forms
{
	[DbContext(typeof(CatContext))]
    [Migration("20161228211058_Initial")]
	partial class Initial
	{
		protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752");

            modelBuilder.Entity("EntityFrameworkWithXamarin.MigrationsBait.Cat", b =>
                {
                    b.Property<int>("CatId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MeowsPerSecond");

                    b.Property<string>("Name");

                    b.HasKey("CatId");

                    b.ToTable("Cats");
                });
        }
	}
}
