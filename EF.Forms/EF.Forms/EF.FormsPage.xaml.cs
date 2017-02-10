using Xamarin.Forms;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Collections.Generic;
using EF.Forms.Data;
using System;

namespace EF.Forms
{
	public partial class EF_FormsPage : ContentPage
	{
		public EF_FormsPage ()
		{
			InitializeComponent ();
		}

		protected async override void OnAppearing()
		{
			var dbFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
          	var fileName = "Cats.db";
          	var dbFullPath = Path.Combine(dbFolder, fileName);
			try
          	{
	            using (var db = new CatContext(dbFullPath))
	            {
	              await db.Database.MigrateAsync(); //We need to ensure the latest Migration was added. This is different than EnsureDatabaseCreated.
	 
	              Cat catGary = new Cat() { CatId = 1, Name = "Gary", MeowsPerSecond = 5 };
	              Cat catJack = new Cat() { CatId = 2, Name = "Jack", MeowsPerSecond = 11 };
	              Cat catLuna = new Cat() { CatId = 3, Name = "Luna", MeowsPerSecond = 3 };
	 
	              List<Cat> catsInTheHat = new List<Cat>() { catGary, catJack, catLuna };
	 
	              if(await db.Cats.CountAsync() < 3)
	              {
	                await db.Cats.AddRangeAsync(catsInTheHat);
	                await db.SaveChangesAsync();
	              }
	 
	              var catsInTheBag = await db.Cats.ToListAsync();
					textView.Text = "";
	              foreach(var cat in catsInTheBag)
	              {
	                textView.Text += $"{cat.CatId} - {cat.Name} - {cat.MeowsPerSecond}" + System.Environment.NewLine;
	              }
	            }
 
          	}
          	catch (Exception ex)
          	{
            	System.Diagnostics.Debug.WriteLine(ex.ToString());
          	}
		}
	}
}
