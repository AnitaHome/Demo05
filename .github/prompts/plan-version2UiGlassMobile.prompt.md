## Plan: version2 操作介面美化（玻璃質感＋手機螢幕）

本計畫將針對 HealthCalculator 前端進行 UI 美化，採用玻璃質感（Glassmorphism）設計，並優化手機螢幕顯示，提升現代感與易用性。

### Steps
1. 新增/修改 CSS 樣式
   - 在 `wwwroot/css/site.css` 增加 glassmorphism 樣式（半透明背景、毛玻璃效果、圓角、陰影）。
   - 強化 Bootstrap 響應式設計，針對手機螢幕（max-width: 480px）優化表單與按鈕排版。

2. 修改 Razor 頁面結構
   - 在 `Pages/Index.cshtml` 將主要表單與結果區塊包覆於 glass 卡片容器。
   - 調整欄位間距、按鈕大小，確保單手操作友善。

3. Layout 與主題色調
   - 在 `_Layout.cshtml` 加入主題背景（漸層或模糊），讓內容區塊浮於背景之上。
   - 統一色彩搭配，按鈕與標題採用現代感配色。

4. 測試與調整
   - 使用瀏覽器開發者工具模擬手機螢幕，微調各元件間距與字體大小。
   - 確認所有功能在 iOS/Android 主流瀏覽器下皆正常顯示。

### Further Considerations
1. 是否需支援深色模式？（可選）
2. 若需動畫效果，可考慮加入 hover/active 狀態的玻璃光暈。
3. 若有 Logo 或品牌色，建議一併融入主題設計。
