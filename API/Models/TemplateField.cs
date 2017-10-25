﻿namespace API.Models
{
    public class TemplateField
    {
        public string Content { get; set; }
        public string Comment { get; set; }

        public new string ToString()
        {
            return $"TemplateField: Name = \"{Content}\", Comment = \"{Comment}\"";
        }
    }
}