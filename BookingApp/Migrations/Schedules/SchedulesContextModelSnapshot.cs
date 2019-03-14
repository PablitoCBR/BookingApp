﻿// <auto-generated />
using BookingApp.Contextes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookingApp.Migrations.Schedules
{
    [DbContext(typeof(SchedulesContext))]
    partial class SchedulesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085");

            modelBuilder.Entity("BookingApp.Entities.Schedule.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BusinessId");

                    b.HasKey("Id");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("BookingApp.Entities.Schedule.Schedule", b =>
                {
                    b.OwnsOne("BookingApp.Entities.Schedule.WorkingHours", "Friday", b1 =>
                        {
                            b1.Property<int>("ScheduleId");

                            b1.ToTable("Schedules");

                            b1.HasOne("BookingApp.Entities.Schedule.Schedule")
                                .WithOne("Friday")
                                .HasForeignKey("BookingApp.Entities.Schedule.WorkingHours", "ScheduleId")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.OwnsOne("BookingApp.Entities.Schedule.Time", "Closeing", b2 =>
                                {
                                    b2.Property<int>("WorkingHoursScheduleId");

                                    b2.Property<int>("Hours");

                                    b2.Property<int>("Minutes");

                                    b2.ToTable("Schedules");

                                    b2.HasOne("BookingApp.Entities.Schedule.WorkingHours")
                                        .WithOne("Closeing")
                                        .HasForeignKey("BookingApp.Entities.Schedule.Time", "WorkingHoursScheduleId")
                                        .OnDelete(DeleteBehavior.Cascade);
                                });

                            b1.OwnsOne("BookingApp.Entities.Schedule.Time", "Opening", b2 =>
                                {
                                    b2.Property<int>("WorkingHoursScheduleId");

                                    b2.Property<int>("Hours");

                                    b2.Property<int>("Minutes");

                                    b2.ToTable("Schedules");

                                    b2.HasOne("BookingApp.Entities.Schedule.WorkingHours")
                                        .WithOne("Opening")
                                        .HasForeignKey("BookingApp.Entities.Schedule.Time", "WorkingHoursScheduleId")
                                        .OnDelete(DeleteBehavior.Cascade);
                                });
                        });

                    b.OwnsOne("BookingApp.Entities.Schedule.WorkingHours", "Monday", b1 =>
                        {
                            b1.Property<int>("ScheduleId");

                            b1.ToTable("Schedules");

                            b1.HasOne("BookingApp.Entities.Schedule.Schedule")
                                .WithOne("Monday")
                                .HasForeignKey("BookingApp.Entities.Schedule.WorkingHours", "ScheduleId")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.OwnsOne("BookingApp.Entities.Schedule.Time", "Closeing", b2 =>
                                {
                                    b2.Property<int>("WorkingHoursScheduleId");

                                    b2.Property<int>("Hours");

                                    b2.Property<int>("Minutes");

                                    b2.ToTable("Schedules");

                                    b2.HasOne("BookingApp.Entities.Schedule.WorkingHours")
                                        .WithOne("Closeing")
                                        .HasForeignKey("BookingApp.Entities.Schedule.Time", "WorkingHoursScheduleId")
                                        .OnDelete(DeleteBehavior.Cascade);
                                });

                            b1.OwnsOne("BookingApp.Entities.Schedule.Time", "Opening", b2 =>
                                {
                                    b2.Property<int>("WorkingHoursScheduleId");

                                    b2.Property<int>("Hours");

                                    b2.Property<int>("Minutes");

                                    b2.ToTable("Schedules");

                                    b2.HasOne("BookingApp.Entities.Schedule.WorkingHours")
                                        .WithOne("Opening")
                                        .HasForeignKey("BookingApp.Entities.Schedule.Time", "WorkingHoursScheduleId")
                                        .OnDelete(DeleteBehavior.Cascade);
                                });
                        });

                    b.OwnsOne("BookingApp.Entities.Schedule.WorkingHours", "Saturday", b1 =>
                        {
                            b1.Property<int>("ScheduleId");

                            b1.ToTable("Schedules");

                            b1.HasOne("BookingApp.Entities.Schedule.Schedule")
                                .WithOne("Saturday")
                                .HasForeignKey("BookingApp.Entities.Schedule.WorkingHours", "ScheduleId")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.OwnsOne("BookingApp.Entities.Schedule.Time", "Closeing", b2 =>
                                {
                                    b2.Property<int>("WorkingHoursScheduleId");

                                    b2.Property<int>("Hours");

                                    b2.Property<int>("Minutes");

                                    b2.ToTable("Schedules");

                                    b2.HasOne("BookingApp.Entities.Schedule.WorkingHours")
                                        .WithOne("Closeing")
                                        .HasForeignKey("BookingApp.Entities.Schedule.Time", "WorkingHoursScheduleId")
                                        .OnDelete(DeleteBehavior.Cascade);
                                });

                            b1.OwnsOne("BookingApp.Entities.Schedule.Time", "Opening", b2 =>
                                {
                                    b2.Property<int>("WorkingHoursScheduleId");

                                    b2.Property<int>("Hours");

                                    b2.Property<int>("Minutes");

                                    b2.ToTable("Schedules");

                                    b2.HasOne("BookingApp.Entities.Schedule.WorkingHours")
                                        .WithOne("Opening")
                                        .HasForeignKey("BookingApp.Entities.Schedule.Time", "WorkingHoursScheduleId")
                                        .OnDelete(DeleteBehavior.Cascade);
                                });
                        });

                    b.OwnsOne("BookingApp.Entities.Schedule.WorkingHours", "Sunday", b1 =>
                        {
                            b1.Property<int>("ScheduleId");

                            b1.ToTable("Schedules");

                            b1.HasOne("BookingApp.Entities.Schedule.Schedule")
                                .WithOne("Sunday")
                                .HasForeignKey("BookingApp.Entities.Schedule.WorkingHours", "ScheduleId")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.OwnsOne("BookingApp.Entities.Schedule.Time", "Closeing", b2 =>
                                {
                                    b2.Property<int>("WorkingHoursScheduleId");

                                    b2.Property<int>("Hours");

                                    b2.Property<int>("Minutes");

                                    b2.ToTable("Schedules");

                                    b2.HasOne("BookingApp.Entities.Schedule.WorkingHours")
                                        .WithOne("Closeing")
                                        .HasForeignKey("BookingApp.Entities.Schedule.Time", "WorkingHoursScheduleId")
                                        .OnDelete(DeleteBehavior.Cascade);
                                });

                            b1.OwnsOne("BookingApp.Entities.Schedule.Time", "Opening", b2 =>
                                {
                                    b2.Property<int>("WorkingHoursScheduleId");

                                    b2.Property<int>("Hours");

                                    b2.Property<int>("Minutes");

                                    b2.ToTable("Schedules");

                                    b2.HasOne("BookingApp.Entities.Schedule.WorkingHours")
                                        .WithOne("Opening")
                                        .HasForeignKey("BookingApp.Entities.Schedule.Time", "WorkingHoursScheduleId")
                                        .OnDelete(DeleteBehavior.Cascade);
                                });
                        });

                    b.OwnsOne("BookingApp.Entities.Schedule.WorkingHours", "Thursday", b1 =>
                        {
                            b1.Property<int>("ScheduleId");

                            b1.ToTable("Schedules");

                            b1.HasOne("BookingApp.Entities.Schedule.Schedule")
                                .WithOne("Thursday")
                                .HasForeignKey("BookingApp.Entities.Schedule.WorkingHours", "ScheduleId")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.OwnsOne("BookingApp.Entities.Schedule.Time", "Closeing", b2 =>
                                {
                                    b2.Property<int>("WorkingHoursScheduleId");

                                    b2.Property<int>("Hours");

                                    b2.Property<int>("Minutes");

                                    b2.ToTable("Schedules");

                                    b2.HasOne("BookingApp.Entities.Schedule.WorkingHours")
                                        .WithOne("Closeing")
                                        .HasForeignKey("BookingApp.Entities.Schedule.Time", "WorkingHoursScheduleId")
                                        .OnDelete(DeleteBehavior.Cascade);
                                });

                            b1.OwnsOne("BookingApp.Entities.Schedule.Time", "Opening", b2 =>
                                {
                                    b2.Property<int>("WorkingHoursScheduleId");

                                    b2.Property<int>("Hours");

                                    b2.Property<int>("Minutes");

                                    b2.ToTable("Schedules");

                                    b2.HasOne("BookingApp.Entities.Schedule.WorkingHours")
                                        .WithOne("Opening")
                                        .HasForeignKey("BookingApp.Entities.Schedule.Time", "WorkingHoursScheduleId")
                                        .OnDelete(DeleteBehavior.Cascade);
                                });
                        });

                    b.OwnsOne("BookingApp.Entities.Schedule.WorkingHours", "Tuesday", b1 =>
                        {
                            b1.Property<int>("ScheduleId");

                            b1.ToTable("Schedules");

                            b1.HasOne("BookingApp.Entities.Schedule.Schedule")
                                .WithOne("Tuesday")
                                .HasForeignKey("BookingApp.Entities.Schedule.WorkingHours", "ScheduleId")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.OwnsOne("BookingApp.Entities.Schedule.Time", "Closeing", b2 =>
                                {
                                    b2.Property<int>("WorkingHoursScheduleId");

                                    b2.Property<int>("Hours");

                                    b2.Property<int>("Minutes");

                                    b2.ToTable("Schedules");

                                    b2.HasOne("BookingApp.Entities.Schedule.WorkingHours")
                                        .WithOne("Closeing")
                                        .HasForeignKey("BookingApp.Entities.Schedule.Time", "WorkingHoursScheduleId")
                                        .OnDelete(DeleteBehavior.Cascade);
                                });

                            b1.OwnsOne("BookingApp.Entities.Schedule.Time", "Opening", b2 =>
                                {
                                    b2.Property<int>("WorkingHoursScheduleId");

                                    b2.Property<int>("Hours");

                                    b2.Property<int>("Minutes");

                                    b2.ToTable("Schedules");

                                    b2.HasOne("BookingApp.Entities.Schedule.WorkingHours")
                                        .WithOne("Opening")
                                        .HasForeignKey("BookingApp.Entities.Schedule.Time", "WorkingHoursScheduleId")
                                        .OnDelete(DeleteBehavior.Cascade);
                                });
                        });

                    b.OwnsOne("BookingApp.Entities.Schedule.WorkingHours", "Wednesday", b1 =>
                        {
                            b1.Property<int>("ScheduleId");

                            b1.ToTable("Schedules");

                            b1.HasOne("BookingApp.Entities.Schedule.Schedule")
                                .WithOne("Wednesday")
                                .HasForeignKey("BookingApp.Entities.Schedule.WorkingHours", "ScheduleId")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.OwnsOne("BookingApp.Entities.Schedule.Time", "Closeing", b2 =>
                                {
                                    b2.Property<int>("WorkingHoursScheduleId");

                                    b2.Property<int>("Hours");

                                    b2.Property<int>("Minutes");

                                    b2.ToTable("Schedules");

                                    b2.HasOne("BookingApp.Entities.Schedule.WorkingHours")
                                        .WithOne("Closeing")
                                        .HasForeignKey("BookingApp.Entities.Schedule.Time", "WorkingHoursScheduleId")
                                        .OnDelete(DeleteBehavior.Cascade);
                                });

                            b1.OwnsOne("BookingApp.Entities.Schedule.Time", "Opening", b2 =>
                                {
                                    b2.Property<int>("WorkingHoursScheduleId");

                                    b2.Property<int>("Hours");

                                    b2.Property<int>("Minutes");

                                    b2.ToTable("Schedules");

                                    b2.HasOne("BookingApp.Entities.Schedule.WorkingHours")
                                        .WithOne("Opening")
                                        .HasForeignKey("BookingApp.Entities.Schedule.Time", "WorkingHoursScheduleId")
                                        .OnDelete(DeleteBehavior.Cascade);
                                });
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
