using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp2.Models
{
    public enum ToDoPriority
    {
        Urgent = 1,
        Important = 2,
        Casual = 3
    }
    public class ToDo
    {
        //id para informar como chave primaria num banco de dados
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public ToDoPriority Priority { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public bool Done { get; set; }
        public DateTime? DoneDate { get; set; } //nullable pq inicia-se nulo 

        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        [NotMapped]
        public bool Edit { get; set; }
    }
}
