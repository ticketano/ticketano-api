using System.ComponentModel.DataAnnotations.Schema;

namespace Ticketano.DAL.Models;

public class EmailTemplates: BaseEntity<int>
{
    public int EventId { get; set; }
    public bool InvoiceEmailAttachPdf { get; set; }
    public string InvoiceEmailSubject { get; set; }
    public string InvoiceEmailTemplate { get; set; }
    public string InvoiceEmailReplyTo { get; set; }
    public string InvoiceEmailBccAddr { get; set; }
    
    public bool ReceiptEmailAttachPdf { get; set; }
    public string ReceiptEmailSubject { get; set; }
    public string ReceiptEmailTemplate { get; set; }
    public string ReceiptEmailReplyTo { get; set; }
    public string ReceiptEmailBccAddr { get; set; }
    
    public bool ReservationEmailAttachPdf { get; set; }
    public string ReservationEmailSubject { get; set; }
    public string ReservationEmailTemplate { get; set; }
    public string ReservationEmailReplyTo { get; set; }
    public string ReservationEmailBccAddr { get; set; }
    
    [ForeignKey(nameof(EventId))]
    public virtual Event Event { get; set; }
}