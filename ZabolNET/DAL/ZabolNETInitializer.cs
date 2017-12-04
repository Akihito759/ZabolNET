using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZabolNET.Models;

namespace ZabolNET.DAL
{
    public class ZabolNETInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ZabolNETContext>
    {
        protected override void Seed(ZabolNETContext context)
        {
            var _faculties = new List<Faculty>
            {
                new Faculty()
                {
                    Courses =
                    {
                        new Course()
                        {
                            CourseName = "IB",
                            Years = new List<Year>()
                            {
                                new Year()
                                {
                                    Groups = new List<Group>()
                                    {
                                        new Group()
                                        {
                                            GroupName = "Koteczki",
                                            Subjects = new List<Subject>()
                                            {
                                                new Subject()
                                                {
                                                    SubjectName = "PUM"
                                                },
                                                new Subject()
                                                {
                                                    SubjectName = "BDM"
                                                }
                                            },

                                            Records = new List<Record>()
                                            {
                                                new Record()
                                                {

                                                    Description = "Działania na kolekcjach, listy, stosy, kolejki",
                                                    RecordDate = DateTime.Now.AddDays(1),
                                                    RecordType = "kartkówka",
                                                    ShortDescription = "Kolekcje"
                                                },
                                                new Record()
                                                {

                                                    Description = "Tworzenie bazy danych, dodawanie i modyfikacja rekordów bazy danych w szpitalu",
                                                    RecordDate = DateTime.Now.AddDays(1),
                                                    RecordType = "kolokwium",
                                                    ShortDescription = "BazaPacjentów"

                                                }

                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
            _faculties.ForEach(s => context.Faculties.Add(s));
            context.SaveChanges();

        }
    }
}

//przepraszam
