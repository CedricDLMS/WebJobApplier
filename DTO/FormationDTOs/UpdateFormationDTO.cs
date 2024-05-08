using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.FormationDTOs
{
    /// <summary>
    /// Represents a DTO for updating formation details.
    /// </summary>
    public class UpdateFormationDTO
    {
        /// <summary>
        /// Gets or sets the ID of the formation.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the school.
        /// </summary>
        public string SchoolName { get; set; }

        /// <summary>
        /// Gets or sets the description of the formation.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the diploma obtained.
        /// </summary>
        public string Diploma { get; set; }

        /// <summary>
        /// Gets or sets the start date of the formation.
        /// </summary>
        public DateTime BeginDate { get; set; }

        /// <summary>
        /// Gets or sets the end date of the formation.
        /// </summary>
        public DateTime EndDate { get; set; }
    }

}