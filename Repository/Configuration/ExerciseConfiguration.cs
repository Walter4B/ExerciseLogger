using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entities.Models;

namespace Repository.Configuration
{
    public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
    {
        public void Configure(EntityTypeBuilder<Exercise> builder)
        {
            builder.HasData
                (
                    new Exercise
                    {
                        Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                        Type = "Cardio",
                        StartTime = new DateTime(2022, 5, 1, 9, 15, 0),
                        EndTime = new DateTime(2022, 5, 1, 10, 0, 0),
                        Duration = new TimeSpan(0, 45, 0),
                        Comments = "Jhon's has a nice view, lacking in equipment but got a good exercise feeling the burn.",
                        GymId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
                    },

                    new Exercise
                    {
                        Id = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                        Type = "Strength",
                        StartTime = new DateTime(2022, 5, 2, 9, 15, 0),
                        EndTime = new DateTime(2022, 5, 2, 10, 45, 0),
                        Duration = new TimeSpan(1, 30, 0),
                        Comments = "Steve's is briliant, they have all the equipmnet I need, before I go I will bench 200kg gonna go slow.",
                        GymId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3")
                    },

                    new Exercise
                    {
                        Id = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                        Type = "Physical",
                        StartTime = new DateTime(2022, 6, 17, 9, 15, 0),
                        EndTime = new DateTime(2022, 6, 17, 9, 45, 0),
                        Duration = new TimeSpan(0, 30, 0),
                        Comments = "Steve's is excelent for physical.",
                        GymId = new Guid("3d490a70-94ce-4d15-9494-5248280c2ce3")
                    }
                );
        }
    }
}
