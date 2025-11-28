# Prototype 規格說明

## 技術架構
- 後端：.NET 9 (C#)
- API：ASP.NET Web API，提供 BMI、BMR、TDEE 計算服務
- 前端：Razor Pages + Bootstrap 5
- 前端互動：JavaScript 呼叫 ASP.NET Web API（與 Razor Pages 同專案）
- 使用者資料儲存：使用 localStorage（localstorage3）於用戶端

---

## 功能設計

### 1. 表單輸入
- 使用者可於網頁表單輸入：
  - 性別
  - 年齡
  - 身高
  - 體重
  - 活動量（TDEE 計算用）

### 2. 按鈕互動
- 下方有三個按鈕：BMI、BMR、TDEE
- 按鈕根據輸入資訊動態啟用/停用：
  - BMI：需身高、體重
  - BMR：需性別、年齡、身高、體重
  - TDEE：需性別、年齡、身高、體重、活動量

### 3. 計算流程
- 使用者按下任一已啟用按鈕時：
  1. 以 JavaScript 取得表單資料
  2. 呼叫 ASP.NET Web API 取得計算結果
  3. 顯示計算結果於網頁
  4. 將目前輸入的身體資料儲存至 localStorage

### 4. 資料載入
- 網頁載入時，若 localStorage 有先前儲存的資料，則自動載入並填入表單

---

## API 設計
- 路徑範例：
  - `/health/bmi`
  - `/health/bmr`
  - `/health/tdee`
- 輸入：JSON 格式，包含必要欄位
- 輸出：計算結果（JSON）

---


## 前端設計
- Razor Pages 建立表單與按鈕
- Bootstrap 5 美化 UI
- JavaScript 處理：
  - 表單驗證
  - 按鈕啟用/停用
  - 呼叫 API 並顯示結果
  - localStorage 資料存取

---

## 驗收標準
1. 使用者能於表單輸入所有必要資訊
2. 按鈕根據輸入動態啟用/停用
3. 按下按鈕後能正確呼叫 API 並顯示結果
4. 使用者資料能正確儲存於 localStorage，並於下次載入自動填入
5. UI 友善、響應式設計

---

## 備註
- 所有功能於同一 ASP.NET 專案實作
- 不需後端資料庫，所有使用者資料僅存在用戶端 localStorage
