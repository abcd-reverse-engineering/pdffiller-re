// Decompiled with JetBrains decompiler
// Type: pdfFiller.UI.FindPdf.FindPdfFilesListViewModel
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using Microsoft.CSharp.RuntimeBinder;
using pdfFiller.di;
using pdfFiller.Model.Pojo.Data;
using pdfFiller.Model.Pojo.Data.Structure;
using pdfFiller.UI.FilesList;
using System;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace pdfFiller.UI.FindPdf;

public class FindPdfFilesListViewModel : FilesListViewModel
{
  private string _currentQuery;
  private bool wasSearch;

  public FindPdfFilesListViewModel() => this.EmptyFolder = Folder.GetMockFindPdfStartFolder();

  protected override bool CanOpenProject() => true;

  protected override string GetBusManagerKey() => "FindPdfViewModel";

  protected override bool IsRecentsCanBeVisible() => false;

  public override void ObserveData(object data)
  {
    // ISSUE: reference to a compiler-generated field
    if (FindPdfFilesListViewModel.\u003C\u003Eo__6.\u003C\u003Ep__0 == null)
    {
      // ISSUE: reference to a compiler-generated field
      FindPdfFilesListViewModel.\u003C\u003Eo__6.\u003C\u003Ep__0 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof (string), typeof (FindPdfFilesListViewModel)));
    }
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    this._currentQuery = FindPdfFilesListViewModel.\u003C\u003Eo__6.\u003C\u003Ep__0.Target((CallSite) FindPdfFilesListViewModel.\u003C\u003Eo__6.\u003C\u003Ep__0, data);
    if (this._currentQuery == "")
    {
      this.EmptyFolder = Folder.GetMockFindPdfStartFolder();
      this.Data = new ObservableCollection<object>();
      this.DocumentsCount = 0;
    }
    else
    {
      this.LoadStructure<string>(this._currentQuery);
      if (this.wasSearch)
        return;
      this.wasSearch = true;
      DIManager.AmplitudeManager.AddEvent("Internal Doc Searched");
    }
  }

  protected override Folder GetEmptyFolder() => Folder.GetMockFindPdfEmptyFolder();

  protected override Task<ProjectsStructure> GetProjectsStructure<T>(
    T data,
    CancellationToken cancellationToken)
  {
    return this.dataManager.SearchDocuments((object) data as string, cancellationToken);
  }

  protected override Task<ProjectsStructure> Paginate(
    ProjectsStructure projectsStructure,
    CancellationToken cancellationToken)
  {
    return this.dataManager.SearchDocuments(this._currentQuery, cancellationToken, projectsStructure.GetNexPage());
  }
}
