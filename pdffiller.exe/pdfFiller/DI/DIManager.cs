// Decompiled with JetBrains decompiler
// Type: pdfFiller.di.DIManager
// Assembly: pdfFiller, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AEBF2585-E3E0-4E31-BEF4-9C2E935A9144
// Assembly location: D:\pdfFiller\pdfFiller.exe

using pdfFiller.api;
using pdfFiller.Bus;
using pdfFiller.data_manager.api;
using pdfFiller.Model.Amplitude;
using pdfFiller.Model.Analytics;
using pdfFiller.Model.Api;
using pdfFiller.storage;
using Refit;
using SimpleInjector;
using System;
using System.Net.Http;
using System.Threading.Tasks;

#nullable disable
namespace pdfFiller.di;

public class DIManager
{
  private static Container container;

  public static DataProvider DataProvider => DIManager.container.GetInstance<DataProvider>();

  public static BusManager BusManager => DIManager.container.GetInstance<BusManager>();

  public static AnalyticsManager AnalyticsManager
  {
    get => DIManager.container.GetInstance<AnalyticsManager>();
  }

  public static AmplitudeManager AmplitudeManager
  {
    get => DIManager.container.GetInstance<AmplitudeManager>();
  }

  public static void Inject()
  {
    DIManager.container = new Container();
    DIManager.container.Register<BusManager, BusManager>((Lifestyle) Lifestyle.Singleton);
    DIManager.container.Register<DataProvider>((Func<DataProvider>) (() => new DataProvider(DIManager.CreateRestService<RestApiInterface>(DIManager.CreateHttpClient(ApiConstants.BASE_URL)), new UserDataStorage())), (Lifestyle) Lifestyle.Singleton);
    DIManager.container.Register<AnalyticsManager>((Func<AnalyticsManager>) (() => new AnalyticsManager(DIManager.CreateRestService<AnalyticsRestInterface>(DIManager.CreateHttpClient("https://www.google-analytics.com")), new UserDataStorage())), (Lifestyle) Lifestyle.Singleton);
    DIManager.container.Register<AmplitudeManager>((Func<AmplitudeManager>) (() => new AmplitudeManager(DIManager.CreateRestService<AmplitudeRestInterface>(DIManager.CreateHttpClient("https://api.amplitude.com")))), (Lifestyle) Lifestyle.Singleton);
    DIManager.container.Verify();
  }

  private static HttpClient CreateHttpClient(string baseUrl)
  {
    return new HttpClient((HttpMessageHandler) new RestApiInterceptor())
    {
      BaseAddress = new Uri(baseUrl),
      Timeout = TimeSpan.FromSeconds(30.0)
    };
  }

  private static T CreateRestService<T>(HttpClient httpClient)
  {
    return RestService.For<T>(httpClient, new RefitSettings()
    {
      ExceptionFactory = new Func<HttpResponseMessage, Task<Exception>>(ApiExceptionsFactory.ExceptionsFactory)
    });
  }
}
