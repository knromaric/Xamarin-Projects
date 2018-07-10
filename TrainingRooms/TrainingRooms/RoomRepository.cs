using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingRooms
{
    public class RoomRepository
    {
        private List<TrainingRoom> _rooms = new List<TrainingRoom>
        {
            new TrainingRoom{
                Id = 1,
                Name = "Copernicus",
                Location = "bldg 1",
                NumberComputers = 25
            },
            new TrainingRoom{
                Id = 2,
                Name = "Zirka",
                Location = "bldg 2",
                NumberComputers = 20
            },
            new TrainingRoom{
                Id = 3,
                Name = "Hewet",
                Location = "bldg 1",
                NumberComputers = 40
            },
            new TrainingRoom{
                Id = 4,
                Name = "Fikra",
                Location = "bldg 3",
                NumberComputers = 37
            }
        };
        public List<TrainingRoom> GetTrainingRooms()
        {
            return _rooms;
        }

        public TrainingRoom GetRoom(int id)
        {
            return _rooms.Where(r => r.Id == id).FirstOrDefault();
        }
    }
}
