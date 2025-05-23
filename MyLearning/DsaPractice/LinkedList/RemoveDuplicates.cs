using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DsaPractice.LinkedList
{
    /*
     *  Leetcode 83
        Given the head of a sorted linked list, delete all duplicates such that each element appears only once.
        Return the linked list sorted as well.
    */
    internal class RemoveDuplicates
    {
        // Definition for singly-linked list.
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        // 1 1 2
        public ListNode DeleteDuplicates(ListNode head)
        {
            var current = head;

            while (current.next != null)
            {
                if (current.val == current.next.val)
                {
                    current.next = current.next.next;
                }
                else
                {
                    current = current.next;
                }
            }

            return head;
        }

        public void Test()
        {
            ListNode head = 
                new ListNode(1, 
                new ListNode(1, 
                new ListNode(2)));

            var result = DeleteDuplicates(head);

            var current = result;
            
            while (current != null)
            {
                Console.WriteLine(current.val);
                current = current.next;
            }
        }
    }
}
