using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace PoloclinicWebAPI.Models.DBContext
{
    public static class InitDB
    {
        public static void InitPoliclinic(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<PoliclinicContext>());
            }
        }

        private static void SeedData(PoliclinicContext context)
        {
            System.Console.WriteLine("Appling...");

            context.Database.EnsureCreated();

            if (!context.MedicalCards.Any())
            {
                System.Console.WriteLine("Adding data");
                context.Qualifications.AddRange(
                    new Qualification() { Name = "Высшая категория" },
                    new Qualification() { Name = "Первая категория" },
                    new Qualification() { Name = "Вторая категория" }
                );
                context.Specializations.AddRange(
                    new Specialization() { Specialization1 = "Терапевт" },
                    new Specialization() { Specialization1 = "Травматолог" },
                    new Specialization() { Specialization1 = "Невролог" },
                    new Specialization() { Specialization1 = "Хирург" },
                    new Specialization() { Specialization1 = "Офтальмолог" },
                    new Specialization() { Specialization1 = "ЛОР" },
                    new Specialization() { Specialization1 = "Гинеколог" },
                    new Specialization() { Specialization1 = "Узист" }
                );
                context.Patients.AddRange(
                    new Patient() { Age = 18, FirstName = "Антон", LastName = "Иванович", Address = "спортивная 17", Phone = "+375339584756", Passport = "НВ2939588" },
                    new Patient() { Age = 22, LastName = "Соболёв" },
                    new Patient() { Age = 36, FirstName = "Эдуард", LastName = "Антропов" },
                    new Patient() { Age = 48, FirstName = "Манижа", LastName = "Зигизмундовна", Phone = "+375478951254", Passport = "ВМ9854782" }
                );
                context.Diagnoses.AddRange(
                    new Diagnosis() { CodeMrb10 = "1", Diagnosis1 = "какой-то диагноз" },
                    new Diagnosis() { CodeMrb10 = "2", Diagnosis1 = "ещё какой-то диагноз" },
                    new Diagnosis() { CodeMrb10 = "3", Diagnosis1 = "третий диагноз" },
                    new Diagnosis() { CodeMrb10 = "4", Diagnosis1 = "четвертый диагноз" }
                );
                context.SaveChanges();
                context.Doctors.AddRange(
                    new Doctor() { Age = 18, FirstName = "Владимир", LastName = "Артурович", Address = "спортивная 17", Phone = "+375661424575", QualificationId = 1, SpecializationId = 1 },
                    new Doctor() { Age = 42, FirstName = "Виктория", LastName = "Целис", Address = "Маратова 22", Phone = "+784589557854", QualificationId = 3, SpecializationId = 4 },
                    new Doctor() { Age = 81, FirstName = "Анастасия ", LastName = "Арнитовна", Address = "Мелонова 21", Phone = "+375336154895", QualificationId = 2, SpecializationId = 5 },
                    new Doctor() { Age = 36, FirstName = "Артём", LastName = "Миронов", Address = "Миронова 104", Phone = "+375155698742", QualificationId = 1, SpecializationId = 7 }
                );
                context.SaveChanges();
                context.MedicalCards.AddRange(
                    new MedicalCard() { IdPatient = 1, IdDoctor = 1, DateOfVisit = new DateTime(2012, 12, 12), ReaseachProtacol = "Чтото в иследовании написано", Conclusion = "Наше заключение", IdDiagnosis = 1, Recomendatein = "Рекомендации которые необходимы для исполнения" },
                    new MedicalCard() { IdPatient = 2, IdDoctor = 3, DateOfVisit = new DateTime(2020, 12, 21), ReaseachProtacol = "Иследование", Conclusion = "Заключеение", IdDiagnosis = 2, Recomendatein = "Рекомендация" },
                    new MedicalCard() { IdPatient = 3, IdDoctor = 2, DateOfVisit = new DateTime(2021, 04, 17), ReaseachProtacol = "Ислед", Conclusion = "Зак", IdDiagnosis = 3, Recomendatein = "Рек" }
                );
                context.SaveChanges();
            }
            else
            {
                System.Console.WriteLine("Already have date");
            }
        }
    }
}