# Copilot Instructions for Demo04

## 專案架構總覽
- 本專案以 .NET 9 (C#) 為後端，採用 ASP.NET Web API 提供健康計算（BMI、BMR、TDEE）服務。
- 前端採用 Razor Pages，結合 Bootstrap 5 進行 UI 設計，並以 JavaScript 呼叫 Web API。
- 使用者資料（性別、年齡、身高、體重、活動量）僅儲存於瀏覽器 localStorage，不使用後端資料庫。

## 主要目錄與檔案
- `Requirement/`：需求、原型、里程碑、甘特圖等文件（如 userstory.md, Prototype.md, milestone.md, ganttchart.md）。
- `.github/copilot-instructions.md`：AI agent 指令文件。

## 關鍵開發流程
- API 路徑不含 `/api/` 前綴，統一使用 `/health/bmi`、`/health/bmr`、`/health/tdee`。
- 前端表單動態啟用/停用三個計算按鈕，依據輸入資料完整性。
- 按下任一計算按鈕時，前端會：
  1. 取得表單資料
  2. 呼叫 Web API 並顯示結果
  3. 將資料存入 localStorage
- 網頁載入時自動從 localStorage 載入資料並填入表單。

## 專案慣例
- 所有功能於同一 ASP.NET 專案實作，API 與 Razor Pages 共用專案結構。
- 不使用資料庫，所有個人資料僅存在用戶端。
- 文件皆存於 `Requirement/` 目錄，便於追蹤需求與進度。

## 重要範例
- API 輸入/輸出皆採用 JSON 格式。
- 需求、原型、時程等皆以 Markdown 文件管理。
- Mermaid 語法用於甘特圖（ganttchart.md），可用 VS Code Mermaid 擴充套件預覽。

## 參考文件
- `Requirement/userstory.md`：使用者故事與驗收標準
- `Requirement/Prototype.md`：技術架構與功能流程
- `Requirement/milestone.md`、`Requirement/ganttchart.md`：專案時程與進度

---

> 請依上述架構與慣例進行程式撰寫、文件產出與自動化流程設計。若有不明確處，請主動詢問需求文件或 Prototype。
