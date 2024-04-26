﻿// <auto-generated />
using System;
using BNI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BNI.Migrations
{
    [DbContext(typeof(BNIContext))]
    [Migration("20240425062752_addfield")]
    partial class addfield
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.28")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BNI.Models.Assignment", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int")
                        .HasColumnName("Member_ID");

                    b.Property<int?>("PositionId")
                        .HasColumnType("int")
                        .HasColumnName("Position_ID");

                    b.Property<int?>("TermId")
                        .HasColumnType("int")
                        .HasColumnName("Term_ID");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("PositionId");

                    b.HasIndex("TermId");

                    b.ToTable("Assignment", (string)null);
                });

            modelBuilder.Entity("BNI.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CompanyAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Job")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("MemberOfCsj")
                        .HasColumnType("bit")
                        .HasColumnName("MemberOfCSJ");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("PlatformId")
                        .HasColumnType("int")
                        .HasColumnName("Platform_ID");

                    b.Property<string>("Position")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SupportInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("YearOfExperience")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("PlatformId");

                    b.ToTable("Contact", (string)null);
                });

            modelBuilder.Entity("BNI.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OrganizerEmail")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("OrganizerName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("datetime");

                    b.Property<string>("Title")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Event", (string)null);
                });

            modelBuilder.Entity("BNI.Models.EventsRegister", b =>
                {
                    b.Property<DateTime?>("AddDate")
                        .HasColumnType("datetime");

                    b.Property<bool?>("Cancel")
                        .HasColumnType("bit");

                    b.Property<int?>("EventId")
                        .HasColumnType("int")
                        .HasColumnName("Event_ID");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("User_ID");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("Events_Register", (string)null);
                });

            modelBuilder.Entity("BNI.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Group", (string)null);
                });

            modelBuilder.Entity("BNI.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Address1")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Address_1");

                    b.Property<string>("Address2")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Address_2");

                    b.Property<bool>("AlternateMeetingPerson")
                        .HasColumnType("bit");

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BillingAddress")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Billing_Address");

                    b.Property<string>("BillingCompany")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Billing_Company");

                    b.Property<string>("BillingEmail")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Billing_Email");

                    b.Property<string>("BusinessSector")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Business_Sector");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("CoC")
                        .HasColumnType("bit");

                    b.Property<string>("Commercialorganizations")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Commitmentinformation")
                        .HasColumnType("bit");

                    b.Property<string>("Company")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Contribute")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<string>("DurationOfParticipation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Facebook")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FieldOfRegistration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Guestreferrals")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Introducer")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("Invoicecommitment")
                        .HasColumnType("bit");

                    b.Property<string>("Language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkWeb")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Link_web");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Meetingcommitment")
                        .HasColumnType("bit");

                    b.Property<string>("Nameofparticipation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ParticipationHistory")
                        .HasColumnType("bit");

                    b.Property<bool>("PaymentCompany")
                        .HasColumnType("bit");

                    b.Property<string>("PaymentName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Phone_Number");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(30)
                        .HasColumnType("nchar(30)")
                        .HasColumnName("Postal_code")
                        .IsFixedLength();

                    b.Property<int>("Profession_ID")
                        .HasColumnType("int")
                        .HasColumnName("Profession_ID");

                    b.Property<string>("Pronoun")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Provice")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("QrCode")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("QR_Code");

                    b.Property<string>("Referrer1")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Referrer_1");

                    b.Property<string>("Referrer2")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Referrer_2");

                    b.Property<bool>("RegulatoryCompliance")
                        .HasColumnType("bit");

                    b.Property<string>("Sex")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("TaxAddress")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("Tax_Address");

                    b.Property<string>("TaxNumber")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)")
                        .HasColumnName("Tax_Number");

                    b.Property<string>("Timeintheindustry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Timeofcompanyestablishment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("User_ID");

                    b.Property<bool>("ViolationOfTheLaw")
                        .HasColumnType("bit");

                    b.Property<string>("Youtube")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Zalo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Profession_ID");

                    b.HasIndex("UserId");

                    b.ToTable("Member", (string)null);
                });

            modelBuilder.Entity("BNI.Models.Platform", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Platform", (string)null);
                });

            modelBuilder.Entity("BNI.Models.Position", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<int?>("GroupId")
                        .HasColumnType("int")
                        .HasColumnName("Group_ID");

                    b.Property<string>("Title")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Position", (string)null);
                });

            modelBuilder.Entity("BNI.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int")
                        .HasColumnName("MemberID");

                    b.Property<int?>("PostCategory")
                        .HasColumnType("int")
                        .HasColumnName("Post_Category");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("View")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MemberId");

                    b.HasIndex("PostCategory");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("BNI.Models.PostsCategory", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Posts_Category", (string)null);
                });

            modelBuilder.Entity("BNI.Models.Profession", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Profession", (string)null);
                });

            modelBuilder.Entity("BNI.Models.Term", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Term", (string)null);
                });

            modelBuilder.Entity("BNI.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("City")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Company")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Country")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Vat")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("VAT");

                    b.Property<string>("Zip")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("BNI.Models.Assignment", b =>
                {
                    b.HasOne("BNI.Models.Member", "Member")
                        .WithMany("Assignments")
                        .HasForeignKey("MemberId")
                        .HasConstraintName("FK_Assignment_Member1");

                    b.HasOne("BNI.Models.Position", "Position")
                        .WithMany("Assignments")
                        .HasForeignKey("PositionId")
                        .HasConstraintName("FK_Assignment_Position");

                    b.HasOne("BNI.Models.Term", "Term")
                        .WithMany("Assignments")
                        .HasForeignKey("TermId")
                        .HasConstraintName("FK_Assignment_Term");

                    b.Navigation("Member");

                    b.Navigation("Position");

                    b.Navigation("Term");
                });

            modelBuilder.Entity("BNI.Models.Contact", b =>
                {
                    b.HasOne("BNI.Models.Platform", "Platform")
                        .WithMany("Contacts")
                        .HasForeignKey("PlatformId")
                        .HasConstraintName("FK_Contact_Platform");

                    b.Navigation("Platform");
                });

            modelBuilder.Entity("BNI.Models.EventsRegister", b =>
                {
                    b.HasOne("BNI.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .HasConstraintName("FK_Events_Register_Event");

                    b.HasOne("BNI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Events_Register_User");

                    b.Navigation("Event");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BNI.Models.Member", b =>
                {
                    b.HasOne("BNI.Models.Profession", "Profession")
                        .WithMany("Members")
                        .HasForeignKey("Profession_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Member_Profession1");

                    b.HasOne("BNI.Models.User", "User")
                        .WithMany("Members")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Member_User");

                    b.Navigation("Profession");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BNI.Models.Position", b =>
                {
                    b.HasOne("BNI.Models.Group", "Group")
                        .WithMany("Positions")
                        .HasForeignKey("GroupId")
                        .HasConstraintName("FK_Position_Group");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("BNI.Models.Post", b =>
                {
                    b.HasOne("BNI.Models.Member", "Member")
                        .WithMany("Posts")
                        .HasForeignKey("MemberId")
                        .HasConstraintName("FK_Posts_Member");

                    b.HasOne("BNI.Models.PostsCategory", "PostCategoryNavigation")
                        .WithMany("Posts")
                        .HasForeignKey("PostCategory")
                        .HasConstraintName("FK_Posts_Posts_Category");

                    b.Navigation("Member");

                    b.Navigation("PostCategoryNavigation");
                });

            modelBuilder.Entity("BNI.Models.Group", b =>
                {
                    b.Navigation("Positions");
                });

            modelBuilder.Entity("BNI.Models.Member", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("Posts");
                });

            modelBuilder.Entity("BNI.Models.Platform", b =>
                {
                    b.Navigation("Contacts");
                });

            modelBuilder.Entity("BNI.Models.Position", b =>
                {
                    b.Navigation("Assignments");
                });

            modelBuilder.Entity("BNI.Models.PostsCategory", b =>
                {
                    b.Navigation("Posts");
                });

            modelBuilder.Entity("BNI.Models.Profession", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("BNI.Models.Term", b =>
                {
                    b.Navigation("Assignments");
                });

            modelBuilder.Entity("BNI.Models.User", b =>
                {
                    b.Navigation("Members");
                });
#pragma warning restore 612, 618
        }
    }
}