namespace ReactChainsaw.API.Transports
{
    public class ToDo
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public string Description { get; set; }

        public DateTime DateCreation { get; set; }

        public DateTime DateModification { get; set; }

        public DateTime? DeadLine { get; set; }

        /// <summary>
        /// Pourcentage de progression
        /// </summary>
        public int Eta { get; set; } 
    }
}
