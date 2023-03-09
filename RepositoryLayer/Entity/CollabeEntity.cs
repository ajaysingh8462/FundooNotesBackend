﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;


namespace RepositoryLayer.Entity
{
    public class CollabeEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CollabeId { get; set; }
        public string CollabeEmail { get; set; }

        [ForeignKey("User")]
        public long UserId { get; set; }
        [JsonIgnore]
        public virtual UserEntity User { get; set; }
        [ForeignKey("Notes")]
        public long NotesId { get; set; }
        [JsonIgnore]
        public virtual NotesEntity Notes { get; set; }


    }
}
