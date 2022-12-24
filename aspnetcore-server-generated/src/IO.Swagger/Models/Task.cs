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

namespace IO.Swagger.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class Task : IEquatable<Task>
    { 
        /// <summary>
        /// Gets or Sets Id
        /// </summary>

        [DataMember(Name="id")]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or Sets ProjectId
        /// </summary>
        [Required]

        [DataMember(Name="projectId")]
        public int ProjectId { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>
        [Required]

        [DataMember(Name="name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets StatusId
        /// </summary>

        [DataMember(Name="statusId")]
        public int? StatusId { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>

        [DataMember(Name="description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Priority
        /// </summary>

        [DataMember(Name="priority")]
        public int? Priority { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Task {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  ProjectId: ").Append(ProjectId).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  StatusId: ").Append(StatusId).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
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
            return obj.GetType() == GetType() && Equals((Task)obj);
        }

        /// <summary>
        /// Returns true if Task instances are equal
        /// </summary>
        /// <param name="other">Instance of Task to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Task other)
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
                    ProjectId == other.ProjectId ||
                    ProjectId != null &&
                    ProjectId.Equals(other.ProjectId)
                ) && 
                (
                    Name == other.Name ||
                    Name != null &&
                    Name.Equals(other.Name)
                ) && 
                (
                    StatusId == other.StatusId ||
                    StatusId != null &&
                    StatusId.Equals(other.StatusId)
                ) && 
                (
                    Description == other.Description ||
                    Description != null &&
                    Description.Equals(other.Description)
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
                    if (ProjectId != null)
                    hashCode = hashCode * 59 + ProjectId.GetHashCode();
                    if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                    if (StatusId != null)
                    hashCode = hashCode * 59 + StatusId.GetHashCode();
                    if (Description != null)
                    hashCode = hashCode * 59 + Description.GetHashCode();
                    if (Priority != null)
                    hashCode = hashCode * 59 + Priority.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(Task left, Task right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Task left, Task right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators

        #region Conversion
        public static implicit operator AkvelonTestTask.Common.Task(IO.Swagger.Models.Task model)
        {
            AkvelonTestTask.Common.Task result;

            if (model is null)
            {
                result = null;
            }
            else
            {
                result = new AkvelonTestTask.Common.Task();
                result.Id = model.Id;
                result.Name = model.Name;
                result.Status = (TaskStatus?)model.StatusId;
                result.Description = model.Description;
                result.Priority = model.Priority;
                result.ProjectId = model.ProjectId;
            }

            return result;
        }

        public static implicit operator IO.Swagger.Models.Task(AkvelonTestTask.Common.Task source)
        {
            IO.Swagger.Models.Task model;

            if (source is null)
            {
                model = null;
            }
            else
            {
                model = new IO.Swagger.Models.Task();
                model.Id = source.Id;
                model.Name = source.Name;
                model.StatusId = (int?)source.Status;
                model.Description = source.Description;
                model.Priority = source.Priority;
                model.ProjectId = source.ProjectId;
            }

            return model;
        }
        #endregion Conversion
    }
}
