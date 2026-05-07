using System;

namespace CSharpPractice.DesignPatterns
{
    /*
     * ============================================================
     * STATE DESIGN PATTERN
     * ============================================================
     *
     * Intent:
     * Allow an object to change its behavior when its internal state changes.
     *
     * Simple meaning:
     *
     * Same object + different state = different behavior.
     *
     * Real-world examples:
     * ------------------------------------------------------------
     * 1. Order: New -> Paid -> Shipped -> Delivered -> Cancelled
     * 2. ATM: NoCard -> CardInserted -> PinVerified -> CashDispensing
     * 3. Document: Draft -> Review -> Approved -> Published
     * 4. Media Player: Playing -> Paused -> Stopped
     * 5. TCP Connection: Closed -> Listen -> Established
     *
     * Main Participants:
     * ------------------------------------------------------------
     *
     * 1. Context
     *    - Main object used by client
     *    - Holds current state
     *
     * 2. State Interface
     *    - Common behavior expected from all states
     *
     * 3. Concrete States
     *    - Each class represents one state
     *    - Each state decides how behavior should work
     *
     * Key insight:
     * ------------------------------------------------------------
     * State pattern removes large if/else or switch statements based on state.
     *
     * Instead of:
     *
     * if (status == "Draft") ...
     * else if (status == "Review") ...
     * else if (status == "Published") ...
     *
     * We move state-specific behavior into separate classes.
     *
     * ============================================================
     */


    // ============================================================
    // STATE INTERFACE
    // ============================================================
    public interface IDocumentState
    {
        void Edit(Document document, string text);

        void SubmitForReview(Document document);

        void Approve(Document document);

        void Publish(Document document);
    }


    // ============================================================
    // CONTEXT
    // ============================================================
    /*
     * The main object.
     *
     * Client works with Document.
     *
     * Internally, Document delegates behavior to current state object.
     */
    public class Document
    {
        private IDocumentState _state;

        public string Content { get; private set; } = string.Empty;

        public Document()
        {
            _state = new DraftState();
        }

        public void ChangeState(IDocumentState state)
        {
            _state = state;
        }

        public void AppendContent(string text)
        {
            Content += text;
        }

        public void Edit(string text)
        {
            _state.Edit(this, text);
        }

        public void SubmitForReview()
        {
            _state.SubmitForReview(this);
        }

        public void Approve()
        {
            _state.Approve(this);
        }

        public void Publish()
        {
            _state.Publish(this);
        }
    }


    // ============================================================
    // CONCRETE STATE - DRAFT
    // ============================================================
    public class DraftState : IDocumentState
    {
        public void Edit(Document document, string text)
        {
            document.AppendContent(text);

            Console.WriteLine("Draft updated.");
        }

        public void SubmitForReview(Document document)
        {
            document.ChangeState(new ReviewState());

            Console.WriteLine("Document submitted for review.");
        }

        public void Approve(Document document)
        {
            Console.WriteLine("Cannot approve directly from Draft.");
        }

        public void Publish(Document document)
        {
            Console.WriteLine("Cannot publish Draft document.");
        }
    }


    // ============================================================
    // CONCRETE STATE - REVIEW
    // ============================================================
    public class ReviewState : IDocumentState
    {
        public void Edit(Document document, string text)
        {
            Console.WriteLine("Cannot edit document while it is under review.");
        }

        public void SubmitForReview(Document document)
        {
            Console.WriteLine("Document is already under review.");
        }

        public void Approve(Document document)
        {
            document.ChangeState(new ApprovedState());

            Console.WriteLine("Document approved.");
        }

        public void Publish(Document document)
        {
            Console.WriteLine("Cannot publish before approval.");
        }
    }


    // ============================================================
    // CONCRETE STATE - APPROVED
    // ============================================================
    public class ApprovedState : IDocumentState
    {
        public void Edit(Document document, string text)
        {
            Console.WriteLine("Cannot edit approved document.");
        }

        public void SubmitForReview(Document document)
        {
            Console.WriteLine("Approved document does not need review again.");
        }

        public void Approve(Document document)
        {
            Console.WriteLine("Document is already approved.");
        }

        public void Publish(Document document)
        {
            document.ChangeState(new PublishedState());

            Console.WriteLine("Document published.");
        }
    }


    // ============================================================
    // CONCRETE STATE - PUBLISHED
    // ============================================================
    public class PublishedState : IDocumentState
    {
        public void Edit(Document document, string text)
        {
            Console.WriteLine("Cannot edit published document.");
        }

        public void SubmitForReview(Document document)
        {
            Console.WriteLine("Published document cannot be submitted for review.");
        }

        public void Approve(Document document)
        {
            Console.WriteLine("Published document is already approved.");
        }

        public void Publish(Document document)
        {
            Console.WriteLine("Document is already published.");
        }
    }


    // ============================================================
    // CLIENT
    // ============================================================
    public class StateTest
    {
        public static void Test()
        {
            var document = new Document();

            document.Edit("Initial draft content. ");
            document.Edit("More draft content. ");

            document.Publish();

            document.SubmitForReview();

            document.Edit("Trying to edit during review. ");

            document.Approve();

            document.Publish();

            document.Edit("Trying to edit after publish. ");
        }
    }
}
