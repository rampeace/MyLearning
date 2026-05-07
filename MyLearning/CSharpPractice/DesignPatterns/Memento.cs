using System;
using System.Collections.Generic;

namespace CSharpPractice.DesignPatterns
{
    /*
     * ============================================================
     * MEMENTO DESIGN PATTERN
     * ============================================================
     *
     * Intent:
     * Capture and restore an object's internal state
     * without exposing its internal implementation details.
     *
     * Simple meaning:
     *
     * Save Snapshot -> Make Changes -> Restore Snapshot
     *
     * Real-world examples:
     * ------------------------------------------------------------
     * 1. Ctrl + Z in MS Word
     * 2. VMware / Hyper-V snapshots
     * 3. Database rollback
     * 4. Git commits / checkout
     * 5. Windows restore points
     * 6. Game save/load systems
     *
     * Main Participants:
     * ------------------------------------------------------------
     *
     * 1. Originator
     *    - The real object whose state changes over time
     *    - Can create snapshots
     *    - Can restore snapshots
     *
     * 2. Memento
     *    - Snapshot object
     *    - Stores historical state
     *
     * 3. Caretaker
     *    - Stores history/snapshots
     *    - Does NOT understand internal details
     *
     * Important insight:
     * ------------------------------------------------------------
     * Memento is NOT about a fixed implementation.
     *
     * Snapshots can be implemented using:
     * - deep copy
     * - serialization
     * - database logs
     * - event sourcing
     * - copy-on-write
     * - diffs
     * - journaling
     *
     * But the INTENT remains same:
     *
     * "Preserve historical recoverable state."
     *
     * ============================================================
     */


    // ============================================================
    // MEMENTO
    // ============================================================
    /*
     * Snapshot object.
     *
     * Stores state captured at a particular moment in time.
     *
     * In real editors, this may contain:
     * - text
     * - formatting
     * - cursor
     * - selection
     * - images
     * - metadata
     *
     * Here we keep it simple.
     */
    public class DocumentSnapshot
    {
        public string Content { get; }

        public int CursorPosition { get; }

        public DateTime CreatedAt { get; }

        public DocumentSnapshot(string content, int cursorPosition)
        {
            Content = content;
            CursorPosition = cursorPosition;
            CreatedAt = DateTime.Now;
        }
    }


    // ============================================================
    // ORIGINATOR
    // ============================================================
    /*
     * The actual object whose state changes over time.
     *
     * Important:
     * The object itself knows:
     * - how to save state
     * - how to restore state
     *
     * External objects should not manually manipulate internals.
     */
    public class TextEditor
    {
        public string Content { get; private set; } = string.Empty;

        public int CursorPosition { get; private set; }

        public void Type(string text)
        {
            Content = Content.Insert(CursorPosition, text);

            CursorPosition += text.Length;
        }

        public void MoveCursor(int position)
        {
            if (position < 0 || position > Content.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(position));
            }

            CursorPosition = position;
        }

        public void Delete(int count)
        {
            if (count <= 0)
            {
                return;
            }

            if (CursorPosition + count > Content.Length)
            {
                count = Content.Length - CursorPosition;
            }

            Content = Content.Remove(CursorPosition, count);
        }

        /*
         * Creates snapshot of current editor state.
         *
         * Similar to:
         * - VM snapshot
         * - Ctrl+Z checkpoint
         * - Restore point
         */
        public DocumentSnapshot Save()
        {
            return new DocumentSnapshot(Content, CursorPosition);
        }

        /*
         * Restore previous state.
         *
         * Important:
         * Snapshot does not restore itself.
         * Originator restores itself using snapshot.
         */
        public void Restore(DocumentSnapshot snapshot)
        {
            Content = snapshot.Content;

            CursorPosition = snapshot.CursorPosition;
        }

        public void Print()
        {
            Console.WriteLine("=================================");
            Console.WriteLine($"Content        : {Content}");
            Console.WriteLine($"Cursor Position: {CursorPosition}");
            Console.WriteLine("=================================");
            Console.WriteLine();
        }
    }


    // ============================================================
    // CARETAKER
    // ============================================================
    /*
     * Stores snapshot history.
     *
     * Important:
     * Caretaker does NOT understand internal details.
     *
     * It only stores snapshots.
     */
    public class DocumentHistory
    {
        private readonly Stack<DocumentSnapshot> _undoStack = new();

        /*
         * Save current state into history.
         */
        public void Push(DocumentSnapshot snapshot)
        {
            _undoStack.Push(snapshot);
        }

        /*
         * Get latest snapshot.
         */
        public DocumentSnapshot Pop()
        {
            if (_undoStack.Count == 0)
            {
                throw new InvalidOperationException("No snapshots available.");
            }

            return _undoStack.Pop();
        }

        public bool HasSnapshots()
        {
            return _undoStack.Count > 0;
        }
    }


    // ============================================================
    // CLIENT
    // ============================================================
    public class MementoTest
    {
        public static void Test()
        {
            var editor = new TextEditor();

            var history = new DocumentHistory();

            /*
             * Initial typing
             */
            history.Push(editor.Save());

            editor.Type("Hello");

            editor.Print();


            /*
             * Save snapshot before next modification
             */
            history.Push(editor.Save());

            editor.Type(" World");

            editor.Print();


            /*
             * Save snapshot before risky modification
             */
            history.Push(editor.Save());

            editor.MoveCursor(5);

            editor.Type(", Ram");

            editor.Print();


            /*
             * Simulate Ctrl + Z
             */
            Console.WriteLine("UNDO #1");

            editor.Restore(history.Pop());

            editor.Print();


            /*
             * Undo again
             */
            Console.WriteLine("UNDO #2");

            editor.Restore(history.Pop());

            editor.Print();


            /*
             * Undo again
             */
            Console.WriteLine("UNDO #3");

            editor.Restore(history.Pop());

            editor.Print();
        }
    }
}
