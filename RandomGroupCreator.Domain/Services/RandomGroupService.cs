﻿using RandomGroupCreator.Domain.Dto;
using RandomGroupCreator.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomGroupCreator.Domain.Services
{
    public class RandomGroupService : IRandomGroupService
    {
        private static readonly Random _randomNumber = new Random();

        //public List<PersonGroupDto> GenerateRandomGroup(List<PersonDto> people, int numberOfPersonInEachGroup, int quantityOfGroup)
        //{
        //    var shuffledPeople = ShufflePeople(people);

        //    if (quantityOfGroup > 0)
        //    {
        //        var personGroupsList = AddPersonPerQuantityOfGroup(shuffledPeople, quantityOfGroup);

        //        return personGroupsList;
        //    }

        //    var partitionPeople = PartitionPeople(shuffledPeople, numberOfPersonInEachGroup);

        //    var personGroupList = new List<PersonGroupDto>();

        //    foreach (var partition in partitionPeople)
        //    {
        //        var personGroup = new PersonGroupDto()
        //        {
        //            PersonGroups = partition
        //        };

        //        personGroupList.Add(personGroup);
        //    }

        //    return personGroupList;
        //}

        public List<GroupDto> AddPersonPerQuantityOfGroup(List<PersonDto> shuffledPeople, int quantityOfGroup)
        {
            var shuffledPeopleCount = shuffledPeople.Count;

            var groupList = new List<GroupDto>();

            if (shuffledPeopleCount == quantityOfGroup)
            {
                for (int i = 0; i <= shuffledPeopleCount - 1; i++)
                {
                    var person = shuffledPeople[i];

                    var group = new GroupDto()
                    {
                        Group = person
                    };

                    groupList.Add(group);
                }
            }

            return groupList;
        }


        public static List<List<PersonDto>> PartitionPeople(List<PersonDto> people, int numberOfPersonInEachGroup)
        {
            return people.Select((x, i) => new { Index = i, Value = x })
                   .GroupBy(x => x.Index / numberOfPersonInEachGroup)
                   .Select(x => x.Select(v => v.Value).ToList())
                   .ToList();
        }

        public List<PersonDto> ShufflePeople(List<PersonDto> people)
        {
            for (int i = people.Count - 1; i > 0; --i)
            {
                var randomNumber = _randomNumber.Next(i + 1);

                var lastPeople = people[i];
                people[i] = people[randomNumber];
                people[randomNumber] = lastPeople;
            }

            return people;
        }

    }
}
