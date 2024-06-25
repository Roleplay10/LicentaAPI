using BusinessLogicLayer.DTOs;
using DataAccessLayer.Models;

namespace BusinessLogicLayer.Builders;

public interface IDocumentBuilder
{
    Document BuildDocument(DocumentDTO document);
}
public class DocumentBuilder : IDocumentBuilder
{
    public Document BuildDocument(DocumentDTO document)
    {
        var documentToSave = new Document
        {
            Type = document.Type
        };
        return documentToSave;
    }

}
