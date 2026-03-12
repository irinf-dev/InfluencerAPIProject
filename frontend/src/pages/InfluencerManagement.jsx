import React from "react";
import { Grid, Typography } from "@mui/material";
import PeopleIcon from "@mui/icons-material/People";
import PublicIcon from "@mui/icons-material/Public";
import PersonIcon from "@mui/icons-material/Person";
import InstagramIcon from "@mui/icons-material/Instagram";
import YouTubeIcon from "@mui/icons-material/YouTube";
import MusicNoteIcon from "@mui/icons-material/MusicNote";
import KpiCard from "../components/ui/KpiCard"; 
import PlatformCard from "../components/ui/PlatformCard"; 

const InfluencerManagement = () => {
  const kpis = [
    { label: "Total Influencers", value: 4, icon: <PeopleIcon />, color: "#1976d2" },
    { label: "Total Followers", value: 85000, icon: <PublicIcon />, color: "#9c27b0" },
    { label: "Average Followers", value: 21250, icon: <PersonIcon />, color: "#f57c00" },
  ];

  const platforms = [
    { name: "Instagram", influencers: 2, followers: 27000, icon: <InstagramIcon />, color: "#E1306C" },
    { name: "YouTube", influencers: 1, followers: 50000, icon: <YouTubeIcon />, color: "#FF0000" },
    { name: "TikTok", influencers: 1, followers: 8000, icon: <MusicNoteIcon />, color: "#000000" },
  ];

  return (
    <main
      style={{
        position: "relative",
        zIndex: 1,
        padding: "0px",
      }}
    >
      <Typography
        variant="h4"
        gutterBottom
        sx={{
          mb: 4,
          mt: 4,
          fontWeight: "bold",
        }}
      >
        Influencer Dashboard
      </Typography>
      
      {/* KPI Cards */}
      <Grid container spacing={3} mb={1}>
        {kpis.map((kpi) => (
          <Grid item xs={12} md={4} key={kpi.label}>
            <KpiCard
              icon={kpi.icon}
              label={kpi.label}
              value={kpi.value}
              color={kpi.color}
              //darkMode={darkMode}
            />
          </Grid>
        ))}
      </Grid>

      {/* Platform Breakdown */}
      <Grid container spacing={3}>
        {platforms.map((platform) => (
          <Grid item xs={12} md={4} key={platform.name}>
            <PlatformCard
              icon={platform.icon}
              name={platform.name}
              influencers={platform.influencers}
              followers={platform.followers}
              color={platform.color}
             // darkMode={darkMode}   // ✅ pass toggle state
/>
          </Grid>
        ))}
      </Grid>
    </main>
  );
};

export default InfluencerManagement;
