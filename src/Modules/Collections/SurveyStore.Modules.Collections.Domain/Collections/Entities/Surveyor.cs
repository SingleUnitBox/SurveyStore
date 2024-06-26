﻿using System;
using System.Collections.Generic;
using SurveyStore.Shared.Abstractions.Kernel.Types;

namespace SurveyStore.Modules.Collections.Domain.Collections.Entities
{
    public class Surveyor
    {
        public SurveyorId Id { get; private set; }
        public string FullName { get; private set; }
        public IEnumerable<Collection> Collections => _collections;
        public IEnumerable<KitCollection> KitCollections => _kitCollections;
        private readonly ICollection<Collection> _collections = new List<Collection>();
        private readonly ICollection<KitCollection> _kitCollections = new List<KitCollection>();

        private Surveyor()
        {

        }

        public Surveyor(Guid id, string fullName)
        {
            Id = id;
            FullName = fullName;
        }

        public static Surveyor Create(Guid id, string firstName, string surname)
            => new(id, firstName + " " + surname);
    }
}