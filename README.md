# Banking Credit System

Bu proje, bir bankacılık kredi sisteminin backend uygulamasıdır. Clean Architecture ve CQRS (Command Query Responsibility Segregation) pattern'leri kullanılarak geliştirilmiştir.

## Proje Yapısı

Proje aşağıdaki katmanlardan oluşmaktadır:

- **Core**: Tüm katmanların kullanabileceği cross-cutting concerns'leri içerir (Exception handling, security, base repository vb.)
- **Domain**: İş domaininin entity'lerini ve business rules'larını içerir
- **Application**: Use case'leri ve business logic'i içerir (CQRS pattern ile)
- **Persistence**: Veritabanı işlemlerini ve konfigürasyonlarını içerir
- **WebAPI**: HTTP endpoint'lerini içerir

## Özellikler

- Bireysel ve Kurumsal Müşteri yönetimi
- Kredi başvuru yönetimi
- Kredi türü yönetimi
- JWT tabanlı kimlik doğrulama
- Exception handling middleware
- Repository pattern implementasyonu
- Entity Framework Core ile ORM
- AutoMapper ile object mapping
- MediatR ile CQRS implementasyonu
- Fluent Validation ile request validation

## Teknolojiler

- .NET 8.0
- Entity Framework Core 8.0
- SQL Server
- AutoMapper
- MediatR
- FluentValidation
- JWT Authentication

## Kurulum

1. Projeyi clone'layın
   git clone https://github.com/ceydaselaamet/BankingCreditSystem.git
   
2. Veritabanını oluşturun
   cd BankingCreditSystem
   dotnet ef database update --project BankingCreditSystem.Persistence --startup-project BankingCreditSystem.WebApi
   
3. Projeyi çalıştırın
   cd BankingCreditSystem.WebApi
   dotnet run

   ### Müşteri İşlemleri

- `POST /api/IndividualCustomers`: Yeni bireysel müşteri oluşturma
- `GET /api/IndividualCustomers/{id}`: Bireysel müşteri detayı
- `GET /api/IndividualCustomers`: Bireysel müşteri listesi
- `PUT /api/IndividualCustomers`: Bireysel müşteri güncelleme
- `DELETE /api/IndividualCustomers/{id}`: Bireysel müşteri silme

### Kredi İşlemleri

- `POST /api/LoanApplications`: Yeni kredi başvurusu
- `GET /api/LoanApplications/{id}`: Kredi başvuru detayı
- `GET /api/LoanTypes`: Kredi türü listesi
