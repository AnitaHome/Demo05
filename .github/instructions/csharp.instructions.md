---
description: 'C# 應用程式開發指引'
applyTo: '**/*.cs'
---

# C# 開發

## C# 指引
- 請使用最新版本 C#，目前為 C# 14 功能。
- 每個函式都需撰寫清楚且簡潔的註解。

## 一般指引
- 審查程式碼變更時，僅提出高信心建議。
- 撰寫易於維護的程式碼，並註明設計決策原因。
- 處理邊界情境並撰寫明確的例外處理。
- 使用外部函式庫或相依套件時，需於註解中說明用途。

## 命名慣例
- 元件名稱、方法名稱及公開成員請使用 PascalCase。
- 私有欄位及區域變數請使用 camelCase。
- 介面名稱請加上 "I" 前綴（如：IUserService）。

## 格式化
- 請依 `.editorconfig` 定義的程式碼格式。
- 優先使用檔案範圍命名空間宣告及單行 using 指令。
- 任何程式區塊（如 if、for、while、foreach、using、try 等）的大括號前需換行。
- 方法的最終 return 陳述式需獨立一行。
- 優先使用模式比對與 switch 運算式。
- 參照成員名稱時請用 `nameof`，勿用字串。
- 公開 API 需撰寫 XML 文件註解，並於適用時加入 `<example>` 與 `<code>` 範例。

## 專案架構與結構
- 指導使用者建立新 .NET 專案並選用合適範本。
- 說明各自動產生檔案及資料夾的用途，協助理解專案結構。
- 示範如何以功能資料夾或領域驅動設計原則組織程式碼。
- 展現模型、服務、資料存取層的正確分離。
- 說明 ASP.NET Core 10 的 Program.cs 及設定系統，包含環境專屬設定。

## Nullable 參考型別
- 變數預設為非 null，並於進入點檢查 null。
- 一律使用 `is null` 或 `is not null`，勿用 `== null` 或 `!= null`。
- 信任 C# null 標註，型別系統保證非 null 時不需額外檢查。

## 資料存取模式
- 指導以 Entity Framework Core 實作資料存取層。
- 說明開發與正式環境可用的選項（SQL Server、SQLite、In-Memory）。
- 示範 repository pattern 實作及其適用時機。
- 展現資料庫遷移與資料初始化。
- 說明高效查詢模式，避免常見效能問題。

## 驗證與授權
- 指導以 JWT Bearer 實作驗證。
- 說明 OAuth 2.0 與 OpenID Connect 在 ASP.NET Core 的應用。
- 示範角色與政策授權。
- 展現與 Microsoft Entra ID（前 Azure AD）整合。
- 說明如何一致性保護 Controller 與 Minimal API。

## 驗證與錯誤處理
- 指導以資料註解與 FluentValidation 實作模型驗證。
- 說明驗證流程及自訂驗證回應。
- 示範以 Middleware 實作全域例外處理。
- 展現 API 一致性錯誤回應。
- 說明 RFC 7807 標準化錯誤回應（Problem Details）實作。

## API 版本管理與文件
- 指導 API 版本管理策略。
- 示範 Swagger/OpenAPI 文件產生。
- 展現端點、參數、回應、驗證的文件撰寫。
- 說明 Controller 與 Minimal API 的版本管理。
- 指導撰寫有助於 API 使用者的文件。

## 日誌與監控
- 指導以 Serilog 或其他 provider 實作結構化日誌。
- 說明日誌等級及使用時機。
- 示範 Application Insights 整合與遙測收集。
- 展現自訂遙測與請求追蹤相關 ID 實作。
- 說明 API 效能、錯誤、使用模式監控。

## 測試
- 關鍵路徑必須撰寫測試案例。
- 指導建立單元測試。
- 測試方法命名與大小寫請依現有檔案風格。
- 示範 API 端點整合測試。
- 展現如何 mock 相依物件。
- 示範驗證與授權邏輯測試。
- 說明 TDD 原則於 API 開發的應用。

## 效能最佳化
- 指導快取策略（記憶體、分散式、回應快取）。
- 說明非同步程式設計模式及其效能意義。
- 示範大量資料分頁、篩選、排序。
- 展現壓縮與其他效能優化。
- 說明 API 效能量測與基準測試。

## 部署與 DevOps
- 指導以 .NET 內建容器化功能（`dotnet publish --os linux --arch x64 -p:PublishProfile=DefaultContainer`）部署 API。
- 說明手動 Dockerfile 與 .NET 容器發佈差異。
- 展現 .NET CI/CD 流程。
- 示範部署至 Azure App Service、Azure Container Apps 或其他主機。
- 展現健康檢查與就緒探針實作。
- 說明不同部署階段的環境設定。
