import React from "react";
import ReactDOM from "react-dom/client";
import "./index.scss";
import App from "./App";
import reportWebVitals from "./reportWebVitals";

import { BrowserRouter, Route, Routes } from "react-router-dom";
import PremiumPage from "./Pages/Premium";
import IndexPage from "./Pages/Index";
import ErrorPage from "./Pages/NotFound";

const root = ReactDOM.createRoot(
  document.getElementById("root") as HTMLElement
);

root.render(
  <React.StrictMode>
    <BrowserRouter>
      <App>
        <Routes>
          <Route index element={<IndexPage />} />
          <Route path="premium" element={<PremiumPage />} />
          <Route path="*" element={<ErrorPage />} />
        </Routes>
      </App>
    </BrowserRouter>
  </React.StrictMode>
);

reportWebVitals();
