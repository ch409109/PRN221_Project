﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BookingTicketOnline.Models
{
	public partial class PRN221_FinalProjectContext : DbContext
	{
		public PRN221_FinalProjectContext()
		{
		}

		public PRN221_FinalProjectContext(DbContextOptions<PRN221_FinalProjectContext> options)
			: base(options)
		{
		}

		public virtual DbSet<Booking> Bookings { get; set; } = null!;
		public virtual DbSet<BookingItem> BookingItems { get; set; } = null!;
		public virtual DbSet<BookingSeatsDetail> BookingSeatsDetails { get; set; } = null!;
		public virtual DbSet<Cinema> Cinemas { get; set; } = null!;
		public virtual DbSet<Discount> Discounts { get; set; } = null!;
		public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
		public virtual DbSet<FoodAndDrink> FoodAndDrinks { get; set; } = null!;
		public virtual DbSet<Movie> Movies { get; set; } = null!;
		public virtual DbSet<MovieCategory> MovieCategories { get; set; } = null!;
		public virtual DbSet<News> News { get; set; } = null!;
		public virtual DbSet<Payment> Payments { get; set; } = null!;
		public virtual DbSet<Revenue> Revenues { get; set; } = null!;
		public virtual DbSet<Role> Roles { get; set; } = null!;
		public virtual DbSet<Room> Rooms { get; set; } = null!;
		public virtual DbSet<Row> Rows { get; set; } = null!;
		public virtual DbSet<Seat> Seats { get; set; } = null!;
		public virtual DbSet<Showtime> Showtimes { get; set; } = null!;
		public virtual DbSet<User> Users { get; set; } = null!;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Booking>(entity =>
			{
				entity.ToTable("Booking");

				entity.HasIndex(e => e.TicketCode, "UQ__Booking__598CF7A3F13C8629")
					.IsUnique();

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.BookingDate).HasColumnType("datetime");

				entity.Property(e => e.CinemaId).HasColumnName("CinemaID");

				entity.Property(e => e.MovieId).HasColumnName("MovieID");

				entity.Property(e => e.Status).HasMaxLength(50);

				entity.Property(e => e.TicketCode)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.UserId).HasColumnName("UserID");

				entity.HasOne(d => d.Cinema)
					.WithMany(p => p.Bookings)
					.HasForeignKey(d => d.CinemaId)
					.HasConstraintName("FK__Booking__CinemaI__4222D4EF");

				entity.HasOne(d => d.Movie)
					.WithMany(p => p.Bookings)
					.HasForeignKey(d => d.MovieId)
					.HasConstraintName("FK__Booking__MovieID__4316F928");

				entity.HasOne(d => d.User)
					.WithMany(p => p.Bookings)
					.HasForeignKey(d => d.UserId)
					.HasConstraintName("FK__Booking__UserID__440B1D61");
			});

			modelBuilder.Entity<BookingItem>(entity =>
			{
				entity.ToTable("BookingItem");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.BookingId).HasColumnName("BookingID");

				entity.Property(e => e.FoodAndDrinksId).HasColumnName("FoodAndDrinksID");

				entity.HasOne(d => d.Booking)
					.WithMany(p => p.BookingItems)
					.HasForeignKey(d => d.BookingId)
					.HasConstraintName("FK__BookingIt__Booki__5441852A");

				entity.HasOne(d => d.FoodAndDrinks)
					.WithMany(p => p.BookingItems)
					.HasForeignKey(d => d.FoodAndDrinksId)
					.HasConstraintName("FK__BookingIt__FoodA__534D60F1");
			});

			modelBuilder.Entity<BookingSeatsDetail>(entity =>
			{
				entity.ToTable("BookingSeatsDetail");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.BookingId).HasColumnName("BookingID");

				entity.Property(e => e.SeatId).HasColumnName("SeatID");

				entity.HasOne(d => d.Booking)
					.WithMany(p => p.BookingSeatsDetails)
					.HasForeignKey(d => d.BookingId)
					.HasConstraintName("FK__BookingSe__Booki__4E88ABD4");

				entity.HasOne(d => d.Seat)
					.WithMany(p => p.BookingSeatsDetails)
					.HasForeignKey(d => d.SeatId)
					.HasConstraintName("FK__BookingSe__SeatI__4D94879B");
			});

			modelBuilder.Entity<Cinema>(entity =>
			{
				entity.ToTable("Cinema");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.City).HasMaxLength(100);

				entity.Property(e => e.Location).HasMaxLength(255);

				entity.Property(e => e.Name).HasMaxLength(100);

				entity.Property(e => e.Status)
					.HasMaxLength(15)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Discount>(entity =>
			{
				entity.ToTable("Discount");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Code).HasMaxLength(50);

				entity.Property(e => e.EndDate).HasColumnType("date");

				entity.Property(e => e.StartDate).HasColumnType("date");
			});

			modelBuilder.Entity<Feedback>(entity =>
			{
				entity.ToTable("Feedback");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Comments).HasMaxLength(1000);

				entity.Property(e => e.CreateAt).HasColumnType("datetime");

				entity.Property(e => e.MovieId).HasColumnName("MovieID");

				entity.Property(e => e.UserId).HasColumnName("UserID");

				entity.HasOne(d => d.Movie)
					.WithMany(p => p.Feedbacks)
					.HasForeignKey(d => d.MovieId)
					.HasConstraintName("FK__Feedback__MovieI__2F10007B");

				entity.HasOne(d => d.User)
					.WithMany(p => p.Feedbacks)
					.HasForeignKey(d => d.UserId)
					.HasConstraintName("FK__Feedback__UserID__2E1BDC42");
			});

			modelBuilder.Entity<FoodAndDrink>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Image).IsUnicode(false);

				entity.Property(e => e.Name).HasMaxLength(100);

				entity.Property(e => e.Status)
					.HasMaxLength(15)
					.IsUnicode(false);
			});

			modelBuilder.Entity<Movie>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Actor).HasMaxLength(255);

				entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

				entity.Property(e => e.Director).HasMaxLength(255);

				entity.Property(e => e.Poster).IsUnicode(false);

				entity.Property(e => e.ReleaseDate).HasColumnType("date");

				entity.Property(e => e.Status).HasMaxLength(50);

				entity.Property(e => e.Title).HasMaxLength(255);

                entity.Property(e => e.Duration).HasColumnType("time");

                entity.Property(e => e.TrailerUrl)
					.HasMaxLength(255)
					.HasColumnName("TrailerURL");

				entity.HasOne(d => d.Category)
					.WithMany(p => p.Movies)
					.HasForeignKey(d => d.CategoryId)
					.HasConstraintName("FK__Movies__Category__286302EC");
			});

			modelBuilder.Entity<MovieCategory>(entity =>
			{
				entity.ToTable("MovieCategory");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Name).HasMaxLength(100);
			});

			modelBuilder.Entity<News>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.CreateAt).HasColumnType("datetime");

				entity.Property(e => e.Image).HasMaxLength(255);

				entity.Property(e => e.Title).HasMaxLength(255);

				entity.Property(e => e.UpdateAt).HasColumnType("datetime");

				entity.HasOne(d => d.CreateByNavigation)
					.WithMany(p => p.News)
					.HasForeignKey(d => d.CreateBy)
					.HasConstraintName("FK__News__CreateBy__31EC6D26");
			});

			modelBuilder.Entity<Payment>(entity =>
			{
				entity.ToTable("Payment");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.BookingId).HasColumnName("BookingID");

				entity.Property(e => e.DiscountId).HasColumnName("DiscountID");

				entity.HasOne(d => d.Booking)
					.WithMany(p => p.Payments)
					.HasForeignKey(d => d.BookingId)
					.HasConstraintName("FK__Payment__Booking__46E78A0C");

				entity.HasOne(d => d.Discount)
					.WithMany(p => p.Payments)
					.HasForeignKey(d => d.DiscountId)
					.HasConstraintName("FK__Payment__Discoun__47DBAE45");
			});

			modelBuilder.Entity<Revenue>(entity =>
			{
				entity.ToTable("Revenue");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.CinemaId).HasColumnName("CinemaID");

				entity.HasOne(d => d.Cinema)
					.WithMany(p => p.Revenues)
					.HasForeignKey(d => d.CinemaId)
					.HasConstraintName("FK__Revenue__CinemaI__4AB81AF0");
			});

			modelBuilder.Entity<Role>(entity =>
			{
				entity.ToTable("Role");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.RoleName).HasMaxLength(50);
			});

			modelBuilder.Entity<Room>(entity =>
			{
				entity.ToTable("Room");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.CinemaId).HasColumnName("CinemaID");

				entity.Property(e => e.Name).HasMaxLength(100);

				entity.HasOne(d => d.Cinema)
					.WithMany(p => p.Rooms)
					.HasForeignKey(d => d.CinemaId)
					.HasConstraintName("FK__Room__CinemaID__38996AB5");
			});

			modelBuilder.Entity<Row>(entity =>
			{
				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.RoomId).HasColumnName("RoomID");

				entity.Property(e => e.RowName)
					.HasMaxLength(50)
					.IsUnicode(false);

				entity.Property(e => e.Type).HasMaxLength(255);

				entity.HasOne(d => d.Room)
					.WithMany(p => p.Rows)
					.HasForeignKey(d => d.RoomId)
					.HasConstraintName("FK__Rows__RoomID__3B75D760");
			});

			modelBuilder.Entity<Seat>(entity =>
			{
				entity.ToTable("Seat");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.RowId).HasColumnName("RowID");

				entity.Property(e => e.SeatName)
					.HasMaxLength(15)
					.IsUnicode(false);

				entity.Property(e => e.Status).HasMaxLength(255);

				entity.HasOne(d => d.Row)
					.WithMany(p => p.Seats)
					.HasForeignKey(d => d.RowId)
					.HasConstraintName("FK__Seat__RowID__3E52440B");
			});

			modelBuilder.Entity<Showtime>(entity =>
			{
				entity.ToTable("Showtime");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.CinemaId).HasColumnName("CinemaID");

				entity.Property(e => e.Date).HasColumnType("datetime");

				entity.Property(e => e.MovieId).HasColumnName("MovieID");

				entity.Property(e => e.RoomId).HasColumnName("RoomID");

				entity.Property(e => e.Showtime1)
					.HasColumnType("datetime")
					.HasColumnName("Showtime");

				entity.HasOne(d => d.Cinema)
					.WithMany(p => p.Showtimes)
					.HasForeignKey(d => d.CinemaId)
					.HasConstraintName("FK__Showtime__Cinema__5812160E");

				entity.HasOne(d => d.Movie)
					.WithMany(p => p.Showtimes)
					.HasForeignKey(d => d.MovieId)
					.HasConstraintName("FK__Showtime__MovieI__571DF1D5");

				entity.HasOne(d => d.Room)
					.WithMany(p => p.Showtimes)
					.HasForeignKey(d => d.RoomId)
					.HasConstraintName("FK__Showtime__RoomID__59063A47");
			});

			modelBuilder.Entity<User>(entity =>
			{
				entity.ToTable("User");

				entity.Property(e => e.Id).HasColumnName("ID");

				entity.Property(e => e.Dob).HasColumnType("date");

				entity.Property(e => e.Email).HasMaxLength(100);

				entity.Property(e => e.FullName).HasMaxLength(100);

				entity.Property(e => e.Password).HasMaxLength(255);

				entity.Property(e => e.PhoneNumber).HasMaxLength(15);

				entity.Property(e => e.RoleId).HasColumnName("RoleID");

				entity.Property(e => e.Status).HasMaxLength(50);

				entity.Property(e => e.Username).HasMaxLength(50);

				entity.HasOne(d => d.Role)
					.WithMany(p => p.Users)
					.HasForeignKey(d => d.RoleId)
					.HasConstraintName("FK__User__RoleID__2B3F6F97");
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
