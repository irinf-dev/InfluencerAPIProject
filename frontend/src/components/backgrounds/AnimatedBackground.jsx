import React from "react";
import "./AnimatedBackground.css";

const AnimatedBackground = ({ children, darkMode }) => {
  const bubbleColor = darkMode ? "#ffffff" : "#1976d2"; // white bubbles in blue mode, blue bubbles in white mode
  const bgColor = darkMode ? "#1976d2" : "#ffffff";     // main background

  return (
    <div
      className="animated-bg"
      style={{
        backgroundColor: bgColor,
        position: "relative",
        minHeight: "100vh",
        width: "100%",
        overflow: "hidden",
        transition: "background-color 0.3s ease",
      }}
    >
      {/* Bubble elements */}
      <div className="bubble" style={{ backgroundColor: bubbleColor }}></div>
      <div className="bubble" style={{ backgroundColor: bubbleColor }}></div>
      <div className="bubble" style={{ backgroundColor: bubbleColor }}></div>
      <div className="bubble" style={{ backgroundColor: bubbleColor }}></div>
      <div className="bubble" style={{ backgroundColor: bubbleColor }}></div>

      {/* Foreground content */}
      <div className="content">
        {children}
      </div>
    </div>
  );
};

export default AnimatedBackground;
