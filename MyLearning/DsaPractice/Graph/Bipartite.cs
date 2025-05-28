using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.Graph
{

    /*
         * ┌─────────────────────────────┐
         * │        Disjoint Sets        │
         * └─────────────────────────────┘
         * 
         * Example:
         *   Set A = { apple, banana }
         *   Set B = { carrot, tomato }
         *   => Sets A and B are disjoint (no shared items).
         * 
         * General Definition:
         *   - No shared elements.
         *   - Not related to edges or connections.
         * 
         * In Graphs:
         *   - Disjointness: no shared vertices between the two sets.
         * 
         * ┌─────────────────────────────┐
         * │      Bipartite Property     │
         * └─────────────────────────────┘
         *   - Adds a rule: connections (edges) are allowed
         *     only between the sets, never within a set.
         *   - There may be multiple valid splits, but not every split works.
         * 
         * If at least one valid split exists where:
         *   - No two nodes within a set are connected by an edge,
         *   - And all edges go between the sets,
         *   → Then the graph is bipartite.
         * 
         * But if no such split exists, then the graph is not bipartite.
         * 
         * If a graph has no odd-length cycles, then we can always color it using 2 colors,
         * such that no two adjacent nodes have the same color.
         *   - No odd-length cycles: A bipartite graph cannot contain any odd-length cycles,
         *     as this would require vertices from the same set to be connected by an edge.
         * 
         * The goal is to separate connected nodes into opposite groups.
         * 
         * Most real-world graphs aren’t purely bipartite. But when solving problems like matching, assignment, classification,
         * we often build or extract a bipartite view of the data to make the algorithms work.
         */

    internal class Bipartite
    {

    }
}
