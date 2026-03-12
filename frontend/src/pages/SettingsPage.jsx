import React from "react";
import { Typography } from "@mui/material";

const SettingsPage = () => {
  return (
    <div className="p-8">
      <Typography variant="h4" gutterBottom>
        Settings
      </Typography>
      <Typography variant="body1">
        Here you can manage preferences like dark mode, account settings, and dashboard customization.
      </Typography>
    </div>
  );
};

export default SettingsPage;
