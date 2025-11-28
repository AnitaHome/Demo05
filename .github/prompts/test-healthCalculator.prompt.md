# HealthCalculator Web API 測試計畫

本計畫旨在確保 `HealthCalculator` API 的正確性與穩定性，涵蓋 BMI、BMR 與 TDEE 三大核心功能的邏輯驗證與 API 整合測試。

## 1. 建立測試專案
*   在解決方案中新增 xUnit 測試專案 (`HealthCalculator.Tests`)。
*   加入必要套件：
    *   `Microsoft.AspNetCore.Mvc.Testing` (整合測試)
    *   `Moq` (模擬物件)
    *   `FluentAssertions` (斷言輔助)

## 2. 單元測試 (Unit Tests) - 驗證核心邏輯
針對 `Services/` 目錄下的服務撰寫測試。

*   **BMI Service (`BmiService`)**:
    *   測試標準計算公式。
    *   測試邊界值狀態判定：
        *   < 18.5 (Underweight)
        *   18.5 - 24.9 (Normal)
        *   24.9 - 29.9 (Overweight)
        *   >= 29.9 (Obese)
*   **BMR Service (`BmrService`)**:
    *   驗證 Mifflin-St Jeor 公式。
    *   確保不同性別 (Male/Female) 計算結果正確 (男性 +5, 女性 -161)。
*   **TDEE Service (`TdeeService`)**:
    *   驗證 BMR 與各級活動量 (Sedentary 到 ExtraActive) 的乘數效應。

## 3. 整合測試 (Integration Tests) - 驗證 API 端點
使用 `WebApplicationFactory` 模擬啟動 API 進行端對端測試。

*   **POST /health/bmi**:
    *   傳送 JSON payload (身高、體重)。
    *   驗證 HTTP 200 OK 回傳。
    *   驗證回傳 JSON 結構包含 BMI 值與狀態。
*   **POST /health/bmr**:
    *   傳送 JSON payload (身高、體重、年齡、性別)。
    *   驗證不同性別參數的 API 回應數值。
*   **POST /health/tdee**:
    *   傳送 JSON payload (含活動量)。
    *   驗證完整流程 (BMR 計算 -> 活動量加成) 的最終數值。

## 4. 異常處理測試 (Edge Cases)
*   **無效輸入驗證**：
    *   身高、體重、年齡為 0 或負數。
    *   驗證是否回傳適當錯誤 (如 HTTP 400 或 500，視目前實作而定)。
*   **列舉值異常**：
    *   傳入無效的 `Gender` 或 `ActivityLevel` 數值。
*   **錯誤處理機制**：
    *   確認 API 是否有全域錯誤處理 (Global Exception Handler)，避免直接暴露系統例外。

## 待確認事項 (Further Considerations)
1.  **Program 類別可見性**：需確認 `Program.cs` 是否已定義 `public partial class Program { }` 以支援整合測試。
2.  **例外轉譯**：目前 Service 層拋出的 `ArgumentException` 是否已在 API 層被轉換為 HTTP 400 Bad Request。
