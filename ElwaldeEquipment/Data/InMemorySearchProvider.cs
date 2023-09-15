using ElwaldeEquipment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElwaldeEquipment
{
    public class InMemorySearchProvider
    {
        readonly IDictionary<string, Equipment> equipments;
        IDictionary<string, ICollection<(string EquipmentId, int Count)>> searchIndex;

        public InMemorySearchProvider(IDictionary<string, Equipment> equipments)
        {
            this.equipments = equipments;
            searchIndex = BuildSearchIndex();
        }

        IDictionary<string, ICollection<(string EquipmentId, int Count)>> BuildSearchIndex()
        {
            // Build search index based on name, tags, and ingredients
            var searchIndex = new Dictionary<string, ICollection<(string, int)>>();
            foreach (var equipment in equipments.Values)
            {
                var terms = equipment.Name!.ToLower().Split()
                    .Concat(equipment.Tags.Select(tag => tag.ToLower()))
                    .Concat(equipment.Performances.SelectMany(function => function.ToLower().Split()))
                    .GroupBy(term => term)
                    .Select<IGrouping<string, string>, (string Term, int TermCount)>(termGroup => (termGroup.Key, termGroup.Count()));
                foreach (var term in terms)
                {
                    if (!searchIndex.ContainsKey(term.Term))
                    {
                        searchIndex[term.Term] = new List<(string, int)>();
                    }
                    searchIndex[term.Term].Add((equipment.Id!, term.TermCount));
                }
            }
            return searchIndex;
        }

        public IEnumerable<Equipment> Search(string query)
        {
      

            return query.ToLower().Split()
                .Where(term => !string.IsNullOrWhiteSpace(term))
                .SelectMany(term => searchIndex.Keys
                    .Where(key => key.StartsWith(term))
                    .SelectMany(key => searchIndex[key]))
                .GroupBy(termCount => termCount.EquipmentId, termCount => termCount.Count)
                .OrderByDescending(termCounts => termCounts.Sum())
                .Select(termCounts => equipments[termCounts.Key]);
        }
    }
}
