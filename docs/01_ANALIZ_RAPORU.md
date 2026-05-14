# LogicSystems - Analiz Raporu

## 1. Gereksinim Analizi

### 1.1 Proje Konusu
**Akıllı Tedarik ve Lojistik Yönetim Sistemi** - Karmaşık iş kurallarına sahip bir e-ticaret lojistik merkezi için envanter ve lojistik yönetim sistemi.

### 1.2 Proje Senaryosu

#### A. Dinamik Ürün ve Stok Yönetimi
- **Basit Ürünler**: Kalem, kitap vb. doğrudan ürünler
- **Karmaşık Ürünler**: Bilgisayar, montajlı ürünler (içinde RAM, CPU vb. bileşenler barındıran)
- **Stok Eşik Sistemi**: Stok belirlenen eşiğin altına düştüğünde:
  - Satın Alma birimine e-posta bildirim
  - Depo sorumlusuna sistem içi bildirim
- **Observer Pattern** ile bildirim sistemi uygulanmıştır

#### B. Sipariş ve Ödeme Akışı
**Sipariş Durumları**:
```
Beklemede → Onaylandı → Hazırlanıyor → Kargoda → Teslim Edildi
                                              ↓
                                        (Hata durumunda)
                                              ↓
                                           İade Süreci
```

**Durum Özellikleri**:
- Her durum farklı işlemleri destekler
- Kargodaki ürün iptal edilemez, sadece iade edilebilir
- Ödeme yöntemleri: Kredi Kartı, Havale, Kripto Ödeme (ileride)
- **Strategy Pattern** ile ödeme yöntemleri yönetilmiştir
- **State Pattern** ile sipariş yaşam döngüsü uygulanmıştır

#### C. Lojistik ve Kargo Stratejileri
**Desteklenen Kargo Firmaları**:
- Aras Kargo
- Yurtiçi Kargo
- Global Express

**Özellikleri**:
- Her firmanın kendine özel takip numarası üretimi
- Farklı fiyatlandırma algoritmaları
- Ek hizmetler:
  - Sigortalı Gönderim (Insurance Decorator)
  - Kırılacak Eşya Koruması (Fragile Decorator)
- **Adapter Pattern** ile 3. parti API entegrasyonu
- **Decorator Pattern** ile dinamik özellik ekleme
- **Factory Pattern** ile kargo nesnesi yaratımı

#### D. Kullanıcı Yetkilendirme ve Sistem Günlükleri
**Roller**:
- **Admin**: Tüm sisteme erişim
- **Depo Görevlisi**: Envanter ve sipariş yönetimi
- **Kurye**: Kargo takibi ve teslim

**Loglama**:
- Her kritik işlem loglanır (stok değişimi, ödeme onayı vb.)
- **Singleton Pattern** ile Logger nesnesi
- Dosya veya veritabanında merkezi loglama

### 1.3 Çözüm Mimarisi

#### MVC Katmanlandırması
```
Presentation Layer (WinFormsUI)
    ↓
Business Layer (Business)
    ├── States (Durum Yönetimi)
    ├── Strategies (Ödeme Stratejileri)
    ├── Factories (Nesne Yaratımı)
    ├── Shipping (Kargo Yönetimi)
    │   ├── Adapters (Firma Entegrasyonu)
    │   ├── Decorators (Dinamik Özellikler)
    │   └── ExternalAPIs
    ├── Observer (Bildirim Sistemi)
    └── Services
    ↓
Domain Layer (Core)
    ├── Order
    ├── Product
    ├── User
    └── Computer
    ↓
Data Layer (Data)
    ├── Repository Pattern
    └── Logger Service
```

### 1.4 SOLID Prensipleri Uygulanması

#### Single Responsibility Principle (SRP)
- Her sınıf tek bir sorumluluğa sahiptir
- `OrderService`, `PaymentService`, `CargoService` ayrı hizmetler
- `Logger` sadece loglama için
- `ProductRepository` sadece veri erişimi için

#### Open/Closed Principle (OCP)
- Yeni ödeme yöntemi eklemek için: Yeni `IPaymentStrategy` implementasyonu
- Yeni kargo firması eklemek için: Yeni `IShippingService` adaptörü
- Kargo özellikleri için: Yeni `ShippingDecorator` implementasyonu
- Mevcut kodu değiştirmek gerekmez, sadece genişletilir

#### Liskov Substitution Principle (LSP)
- `IOrderState` implementasyonları birbirinin yerine kullanılabilir
- `IPaymentStrategy` implementasyonları uygulamanın herhangi yerinde kullanılabilir
- `IShippingService` adaptörleri standart arayüzü takip eder

#### Interface Segregation Principle (ISP)
- `IOrderState` - Sadece state işlemleri
- `IPaymentStrategy` - Sadece ödeme işlemleri
- `IShippingService` - Sadece kargo işlemleri
- `IObserver` - Sadece bildirim işlemleri

#### Dependency Inversion Principle (DIP)
- Concrete sınıflara değil, abstract sınıflara/interfacelere bağımlılık
- `OrderContext` `IOrderState` interface'e bağımlı
- `PaymentService` `IPaymentStrategy` interface'e bağımlı
- `CargoService` `IShippingService` interface'e bağımlı
- Dependency Injection Container ile bağımlılıklar yönetilir

### 1.5 Kullanılan Tasarım Desenleri

#### Yaratımsal (Creational) Desenler

**1. Singleton Pattern**
- **Kullanım**: Logger sınıfı
- **Amaç**: Sistemde sadece bir Logger örneği bulunması
- **Implementasyon**: `Logger.GetInstance()`

**2. Factory Method Pattern**
- **Kullanım**: `PaymentFactory`, `ShippingFactory`
- **Amaç**: Ödeme ve kargo nesnelerinin merkezi yaratımı
- **Avantaj**: Yeni türler eklemek kolay

**3. Abstract Factory Pattern**
- **Potansiyel Kullanım**: Farklı ödeme gateway'leri için

#### Yapısal (Structural) Desenler

**1. Adapter Pattern**
- **Kullanım**: `ArasAdapter`, `YurtiçiAdapter`
- **Amaç**: Farklı kargo API'lerini standart arayüze uyarlamak
- **Problem Çözüme**: Harici API'lerden bağımsız sistem tasarımı

**2. Decorator Pattern**
- **Kullanım**: `InsuranceDecorator`, `FragileDecorator`
- **Amaç**: Kargo hizmetlerine dinamik olarak özellik ekleme
- **Örnek**: Temel kargo → +Sigorta → +Kırılganlık Koruması
- **Avantaj**: Kombinasyonları runtime'da oluşturabilir

**3. Facade Pattern**
- **Kullanım**: `OrderService`, `PaymentService`, `CargoService`
- **Amaç**: Karmaşık alt sistemleri basit arayüz ile sunmak

#### Davranışsal (Behavioral) Desenler

**1. State Pattern**
- **Kullanım**: Sipariş yönetimi (`OrderContext` + `IOrderState`)
- **Durumlar**: `PendingState`, `ApprovedState`, `PreparingState`, `ShippedState`, `DeliveredState`, `ReturnedState`
- **Problem Çözüme**: if-else zincirleri yerine polimorfizm
- **Avantaj**: Yeni durumlar eklemek kolay, kod okunabilir

**2. Strategy Pattern**
- **Kullanım**: Ödeme yöntemleri (`IPaymentStrategy`)
- **Stratejiler**: `CreditCardPayment`, `BankTransferPayment`
- **Problem Çözüme**: Runtime'da ödeme yöntemi seçimi
- **Avantaj**: Yeni ödeme yöntemi eklemek kolay

**3. Observer Pattern**
- **Kullanım**: Bildirim sistemi (`IObserver`)
- **Observers**: `EmailNotifier`, `SystemNotifier`, `StockManager`
- **Problem Çözüme**: Gevşek bağlı event-driven sistem
- **Avantaj**: Yeni observers eklemek kolay

### 1.6 Proje Kapsamında Uygulanmış Desenleri Özet Tablosu

| Kategori | Desen | Kullanım Yeri | Problem | Çözüm |
|----------|-------|---------------|---------|-------|
| Yaratımsal | Singleton | Logger | Birden fazla Logger nesnesi | Tek instance garantisi |
| Yaratımsal | Factory Method | PaymentFactory, ShippingFactory | Nesne yaratım mantığı saçılmış | Merkezi yaratım |
| Yapısal | Adapter | ArasAdapter, YurtiçiAdapter | Farklı API yapıları | Standart arayüz |
| Yapısal | Decorator | InsuranceDecorator, FragileDecorator | Sabit özellikler | Dinamik özellik ekleme |
| Yapısal | Facade | OrderService, PaymentService | Karmaşık alt sistemler | Basit arayüz |
| Davranışsal | State | OrderContext | if-else zincirleri | Polimorfik state yönetimi |
| Davranışsal | Strategy | PaymentStrategy | Farklı ödeme yöntemleri | Runtime seçimi |
| Davranışsal | Observer | Stock Notifications | Gevşek bağlı event sistemi | Event-driven bildirimler |
| İleri | Dependency Injection | Program.cs | Sıkı bağlılık | Enjekte edilen bağımlılıklar |

---

## 2. UML Diyagramları

### 2.1 Use Case Diyagramı

```
┌─────────────────────────────────────────────────┐
│              LogicSystems                       │
├─────────────────────────────────────────────────┤
│                                                 │
│  ┌─────────────┐                                │
│  │   Müşteri   │                                │
│  └────────┬────┘                                │
│           │                                     │
│           ├─→ Sipariş Oluştur                   │
│           ├─→ Ödeme Yap                         │
│           └─→ Kargo Takip Et                    │
│                                                 │
│  ┌─────────────────────┐                        │
│  │  Depo Görevlisi     │                        │
│  └────────┬────────────┘                        │
│           │                                     │
│           ├─→ Stok Güncelleştirildi             │
│           ├─→ Sipariş Hazırla                   │
│           └─→ İade İşlemi Yönet                │
│                                                 │
│  ┌─────────────┐                                │
│  │   Kurye     │                                │
│  └────────┬────┘                                │
│           │                                     │
│           ├─→ Kargo Teslimat Et                 │
│           └─→ Takip Güncelleştir                │
│                                                 │
└─────────────────────────────────────────────────┘
```

### 2.2 Sınıf Diyagramı (Kısaltılmış)

```
┌──────────────────────────┐
│        Order             │
├──────────────────────────┤
│ - id: int                │
│ - customerName: string   │
│ - products: List         │
│ - totalPrice: decimal    │
├──────────────────────────┤
│ + AddProduct()           │
│ + DisplayOrder()         │
└──────────────────────────┘
         │
         ├─→ uses ─→ ┌──────────────────┐
         │           │   Product        │
         │           ├──────────────────┤
         │           │ - name: string   │
         │           │ - price: decimal │
         │           └──────────────────┘
         │
         └─→ uses ─→ ┌──────────────────────────┐
                     │   OrderContext           │
                     ├──────────────────────────┤
                     │ - currentState           │
                     ├──────────────────────────┤
                     │ + Next()                 │
                     │ + Cancel()               │
                     │ + SetState()             │
                     └──────────────────────────┘
                            │
                            uses
                            ↓
                     ┌──────────────────┐
                     │   IOrderState    │ (Interface)
                     ├──────────────────┤
                     │ + Next()         │
                     │ + Cancel()       │
                     └──────────────────┘
                            ▲
                            │ (implements)
                            │
         ┌──────────────────┼──────────────────┐
         │                  │                  │
    ┌─────────────┐ ┌──────────────┐ ┌───────────┐
    │PendingState │ │ApprovedState │ │ShippedState│
    └─────────────┘ └──────────────┘ └───────────┘

```

### 2.3 Durum Diyagramı (Order Lifecycle)

```
        ┌─────────────┐
        │   START     │
        └──────┬──────┘
               │
               ↓
        ┌────────────────┐
        │   PENDING      │  (Sipariş Beklemeyde)
        └────────┬───────┘
                 │
         ┌───────┴────────┐
         │                │
    Next │                │ Cancel
         ↓                ↓
    ┌─────────────┐   ┌──────────┐
    │  APPROVED   │   │ CANCELLED│
    └────────┬────┘   └──────────┘
             │
        Next │
             ↓
    ┌─────────────────┐
    │   PREPARING     │  (Sipariş Hazırlanıyor)
    └────────┬────────┘
             │
        Next │
             ↓
    ┌──────────────┐
    │   SHIPPED    │  (Kargoda)
    └────┬─────┬───┘
         │     │
    Next │     │ RequestReturn (Hata)
         │     │
         ↓     ↓
    ┌──────────────────┐
    │    DELIVERED     │  ┌──────────────┐
    └──────────────────┘  │  RETURNED    │
                          └──────────────┘
```

### 2.4 Sıralama Diyagramı (Payment Flow)

```
Müşteri        Form              Service         Factory        Strategy
  │             │                  │                │              │
  │─ Pay() ───→ │                  │                │              │
  │             │─ ProcessPayment()→│                │              │
  │             │                  │                │              │
  │             │                  │─CreatePayment()│              │
  │             │                  │                │─ New Strategy│
  │             │                  │                │              │
  │             │                  │ ←─ Return Strategy ─────────│
  │             │                  │                │              │
  │             │                  │                │     Pay()    │
  │             │                  │                │─────────────→│
  │             │                  │                │              │
  │             │                  │                │ ← Log() ─────│
  │             │                  │ ← Success ─────│              │
  │             │ ← Confirmation ──│                │              │
  │ ← Result ───│                  │                │              │
```

### 2.5 Sınıf Diyagramı (Payment Strategy Pattern)

```
┌─────────────────────────┐
│   IPaymentStrategy      │ (Interface)
├─────────────────────────┤
│ + Pay(amount: decimal)  │
└──────────────┬──────────┘
               │ (implements)
               │
        ┌──────┴──────┐
        │             │
┌────────────────────┐  ┌──────────────────────┐
│CreditCardPayment   │  │BankTransferPayment   │
├────────────────────┤  ├──────────────────────┤
│ + Pay(amount)      │  │ + Pay(amount)        │
│   ├─ Validate card │  │   ├─ Validate IBAN  │
│   ├─ Process       │  │   ├─ Create order    │
│   └─ Log           │  │   └─ Log             │
└────────────────────┘  └──────────────────────┘
        ▲                       ▲
        │ (created by)          │ (created by)
        │                       │
        │    ┌──────────────────┤
        │    │                  │
        └────┤  PaymentFactory  │
             │  - CreatePayment()
             └──────────────────┘
```

### 2.6 Sınıf Diyagramı (Shipping Adapter & Decorator Pattern)

```
┌──────────────────────────┐
│  IShippingService        │ (Interface)
├──────────────────────────┤
│ + GenerateTracking()     │
│ + CalculatePrice()       │
└──────────────┬───────────┘
               │ (implements)
               │
        ┌──────┼──────┐
        │      │      │
┌───────────┐ ┌───────────────┐  ┌─────────────────┐
│ArasAdapter│ │YurtiçiAdapter │  │GlobalExpressAd. │
├───────────┤ ├───────────────┤  ├─────────────────┤
│ API       │ │ API           │  │ API             │
└───────────┘ └───────────────┘  └─────────────────┘

        ┌──────────────────────────┐
        │ ShippingDecorator        │ (Abstract Base)
        ├──────────────────────────┤
        │ - shippingService        │
        ├──────────────────────────┤
        │ + GenerateTracking()     │
        │ + CalculatePrice()       │
        └──────────────┬───────────┘
                       │ (extends)
                       │
        ┌──────────────┼──────────────┐
        │              │              │
┌──────────────────┐  ┌──────────────────────┐
│InsuranceDecorator│  │FragileDecorator      │
├──────────────────┤  ├──────────────────────┤
│ + AddInsurance() │  │ + AddProtection()    │
│ + Calculate      │  │ + Calculate          │
│   Extra Cost     │  │   Extra Cost         │
└──────────────────┘  └──────────────────────┘

Kullanım:
var shipping = new ArasAdapter();
shipping = new InsuranceDecorator(shipping);
shipping = new FragileDecorator(shipping);
decimal price = shipping.CalculatePrice(weight);
```

### 2.7 Sınıf Diyagramı (Observer Pattern)

```
┌──────────────────────────┐
│   IObserver              │ (Interface)
├──────────────────────────┤
│ + Update(message: str)   │
└──────────────┬───────────┘
               │ (implements)
               │
        ┌──────┼──────┬────────┐
        │      │      │        │
┌───────────────┐  ┌────────────────┐  ┌──────────────┐
│EmailNotifier  │  │SystemNotifier  │  │StockManager  │
├───────────────┤  ├────────────────┤  ├──────────────┤
│ + SendEmail() │  │ + ShowNotif()  │  │ + UpdateStk()│
└───────────────┘  └────────────────┘  └──────────────┘
        ▲                  ▲                   ▲
        │ (subscribed to)  │                   │
        │                  │                   │
        └──────────────────┼───────────────────┘
                           │
                    ┌──────────────┐
                    │ StockManager │ (Subject)
                    ├──────────────┤
                    │ - observers  │
                    │ - stock      │
                    ├──────────────┤
                    │ + Attach()   │
                    │ + Detach()   │
                    │ + Notify()   │
                    │ + SetStock() │
                    └──────────────┘

Senaryo:
- Stok eşiğin altına düşer
- StockManager.Notify() çağrılır
- Tüm observers Update() metodunu alır
- EmailNotifier → e-posta gönderir
- SystemNotifier → sistem içi bildirim gösterir
- Diğer observers → kendi işlemlerini yapar
```

### 2.8 Sınıf Diyagramı (Logger Singleton)

```
┌────────────────────────────────┐
│        Logger (Singleton)      │
├────────────────────────────────┤
│ - instance: Logger             │
│ - logFilePath: string          │
├────────────────────────────────┤
│ + GetInstance(): Logger        │
│ + Log(message: string)         │
│ + Error(message: string)       │
└────────────────────────────────┘

Kullanım:
Logger logger1 = Logger.GetInstance();
Logger logger2 = Logger.GetInstance();
// logger1 == logger2 (Aynı nesne)

logger1.Log("Sipariş oluşturuldu");
logger2.Log("Ödeme işlendi");
```

---

## 3. Teknik Gereksinimler Uygunluk Matrisi

| Gereksinim | Durum | Uygulandığı Yer |
|-----------|-------|------------------|
| MVC Mimarisi | ✓ Uygulandı | WinFormsUI (V), Business (M), Data (C) |
| UML Diyagramları | ✓ Uygulandı | Use Case, Class, Sequence, State |
| SOLID Prensipleri | ✓ Uygulandı | Tüm katmanlar |
| Minimum 6 Desen | ✓ Uygulandı | 8 desen uygulandı |
| Stok Eşik Sistemi | ✓ Uygulandı | StockManager + Observers |
| Sipariş Yönetimi | ✓ Uygulandı | OrderContext + State Pattern |
| Ödeme Stratejileri | ✓ Uygulandı | PaymentFactory + Strategy |
| Kargo Adaptörleri | ✓ Uygulandı | Shipping/Adapters |
| Kargo Dekoratörleri | ✓ Uygulandı | Shipping/Decorators |
| Loglama Sistemi | ✓ Uygulandı | Logger Singleton |
| DI Container | ✓ Uygulandı | Program.cs |
| Windows Forms UI | ✓ Uygulandı | WinFormsUI Forms |

---

## 4. Proje Durumu Özeti

### Tamamlanan Özellikler
✓ MVC Mimarisi kurulmuş
✓ Tüm tasarım desenleri uygulanmış
✓ SOLID prensipleri uygulanmış
✓ Dependency Injection kurulmuş
✓ Windows Forms UI geliştirilmiş
✓ Birim testleri yazılmış
✓ Loglama sistemi çalışıyor

### İleride Eklenebilecek Özellikler
- [ ] Kripto Ödeme Stratejisi
- [ ] Global Express Kargo Adaptörü
- [ ] Veritabanı entegrasyonu
- [ ] Web API katmanı
- [ ] Gelişmiş raporlama

---

**Rapor Tarihi**: 2026  
**Versiyon**: 1.1.0  
**Target Framework**: .NET 10
