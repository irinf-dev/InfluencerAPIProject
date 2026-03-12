import React from "react";
import { Card, CardContent, Typography } from "@mui/material";

const PlatformCard = ({ icon, name, influencers, followers, color, darkMode }) => {
  return (
    <Card
      sx={{
        background: darkMode
          ? "rgba(255, 255, 255, 0.08)"   // frosted glass on blue background
          : "rgba(0, 0, 0, 0.05)",        // subtle frosted on white background
        backdropFilter: "blur(12px)",
        borderRadius: "16px",
        boxShadow: "0 4px 30px rgba(0,0,0,0.1)",
        color: darkMode ? "#fff" : "#000", // text adapts
      }}
    >
      <CardContent>
        <Typography
          variant="h6"
          sx={{ display: "flex", alignItems: "center", gap: 1, color }}
        >
          {icon} {name}
        </Typography>
        <Typography variant="body1">
          {influencers} influencers
        </Typography>
        <Typography variant="body2">
          {followers.toLocaleString()} followers
        </Typography>
      </CardContent>
    </Card>
  );
};

export default PlatformCard;
