using AkvelonTestTask.Common;
using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace IO.Swagger.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class Project : IEquatable<Project>
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>

        [DataMember(Name = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [Required]

        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets StartDate
        /// </summary>

        [DataMember(Name = "startDate")]
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Gets or Sets CompletionDate
        /// </summary>

        [DataMember(Name = "completionDate")]
        public DateTime? CompletionDate { get; set; }

        /// <summary>
        /// Gets or Sets StatusId
        /// </summary>

        [DataMember(Name = "statusId")]
        public int? StatusId { get; set; }

        /// <summary>
        /// Gets or Sets Priority
        /// </summary>

        [DataMember(Name = "priority")]
        public int? Priority { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Project {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  StartDate: ").Append(StartDate).Append("\n");
            sb.Append("  CompletionDate: ").Append(CompletionDate).Append("\n");
            sb.Append("  StatusId: ").Append(StatusId).Append("\n");
            sb.Append("  Priority: ").Append(Priority).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Project)obj);
        }

        /// <summary>
        /// Returns true if Project instances are equal
        /// </summary>
        /// <param name="other">Instance of Project to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Project other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Id == other.Id ||
                    Id != null &&
                    Id.Equals(other.Id)
                ) &&
                (
                    Name == other.Name ||
                    Name != null &&
                    Name.Equals(other.Name)
                ) &&
                (
                    StartDate == other.StartDate ||
                    StartDate != null &&
                    StartDate.Equals(other.StartDate)
                ) &&
                (
                    CompletionDate == other.CompletionDate ||
                    CompletionDate != null &&
                    CompletionDate.Equals(other.CompletionDate)
                ) &&
                (
                    StatusId == other.StatusId ||
                    StatusId != null &&
                    StatusId.Equals(other.StatusId)
                ) &&
                (
                    Priority == other.Priority ||
                    Priority != null &&
                    Priority.Equals(other.Priority)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                if (Id != null)
                    hashCode = hashCode * 59 + Id.GetHashCode();
                if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                if (StartDate != null)
                    hashCode = hashCode * 59 + StartDate.GetHashCode();
                if (CompletionDate != null)
                    hashCode = hashCode * 59 + CompletionDate.GetHashCode();
                if (StatusId != null)
                    hashCode = hashCode * 59 + StatusId.GetHashCode();
                if (Priority != null)
                    hashCode = hashCode * 59 + Priority.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(Project left, Project right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Project left, Project right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators

        #region Conversion
        public static implicit operator AkvelonTestTask.Common.Project(IO.Swagger.Models.Project model)
        {
            AkvelonTestTask.Common.Project result;

            if (model is null)
            {
                result = null;
            }
            else
            {
                result = new AkvelonTestTask.Common.Project();
                result.Id = model.Id;
                result.Name = model.Name;
                result.StartDate = model.StartDate;
                result.CompletionDate = model.CompletionDate;
                result.Status = (ProjectStatus?)model.StatusId;
                result.Priority = model.Priority;
            }

            return result;
        }

        public static implicit operator IO.Swagger.Models.Project(AkvelonTestTask.Common.Project source)
        {
            IO.Swagger.Models.Project model;

            if (source is null)
            {
                model = null;
            }
            else
            {
                model = new IO.Swagger.Models.Project();
                model.Id = source.Id;
                model.Name = source.Name;
                model.StartDate = source.StartDate;
                model.CompletionDate = source.CompletionDate;
                model.StatusId = (int?)source.Status;
                model.Priority = source.Priority;
            }

            return model;
        }
        #endregion Conversion
    }
}
