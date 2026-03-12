import React from "react";
import {
  AppBar,
  Toolbar,
  Typography,
  IconButton,
  Drawer,
  List,
  ListItem,
  ListItemIcon,
  ListItemText,
  Switch,
} from "@mui/material";
import MenuIcon from "@mui/icons-material/Menu";
import DashboardIcon from "@mui/icons-material/Dashboard";
import PeopleIcon from "@mui/icons-material/People";
import BarChartIcon from "@mui/icons-material/BarChart";
import SettingsIcon from "@mui/icons-material/Settings";
import AnimatedBackground from "../backgrounds/AnimatedBackground";

const drawerWidthOpen = 240;
const drawerWidthClosed = 72;

const SidebarLayout = ({ children, darkMode, setDarkMode }) => {
  const [open, setOpen] = React.useState(true);

  const toggleDrawer = () => setOpen(!open);

  return (
    <div style={{ display: "flex", minHeight: "100vh", position: "relative" }}>
      {/* ✅ Background sits behind everything */}
      <AnimatedBackground darkMode={darkMode} />

      {/* Sidebar */}
      <Drawer
        variant="permanent"
        sx={{
          width: open ? drawerWidthOpen : drawerWidthClosed,
          flexShrink: 0,
          "& .MuiDrawer-paper": {
            width: open ? drawerWidthOpen : drawerWidthClosed,
            boxSizing: "border-box",
            transition: "width 0.3s",
            backgroundColor: darkMode ? "#1976d2" : "#ffffff",
            color: darkMode ? "#fff" : "#000",
          },
        }}
      >
        <Toolbar />
        <List>
          <ListItem button>
            <ListItemIcon sx={{ color: darkMode ? "#fff" : "#1976d2" }}>
              <DashboardIcon />
            </ListItemIcon>
            {open && <ListItemText primary="Overview" />}
          </ListItem>
          <ListItem button>
            <ListItemIcon sx={{ color: darkMode ? "#fff" : "#1976d2" }}>
              <PeopleIcon />
            </ListItemIcon>
            {open && <ListItemText primary="Influencers" />}
          </ListItem>
          <ListItem button>
            <ListItemIcon sx={{ color: darkMode ? "#fff" : "#1976d2" }}>
              <BarChartIcon />
            </ListItemIcon>
            {open && <ListItemText primary="Analytics" />}
          </ListItem>
          <ListItem button>
            <ListItemIcon sx={{ color: darkMode ? "#fff" : "#1976d2" }}>
              <SettingsIcon />
            </ListItemIcon>
            {open && <ListItemText primary="Settings" />}
          </ListItem>
        </List>
      </Drawer>

      {/* Main Content */}
      <div style={{ flexGrow: 1 }}>
        <AppBar
          position="fixed"
          sx={{
            zIndex: 1201,
            backgroundColor: darkMode ? "#1976d2" : "#ffffff",
            color: darkMode ? "#fff" : "#000",
            transition: "all 0.3s ease",
          }}
        >
          <Toolbar>
            <IconButton edge="start" color="inherit" onClick={toggleDrawer}>
              <MenuIcon />
            </IconButton>
            <Typography
              variant="h6"
              sx={{
                flexGrow: 1,
                fontWeight: "bold",
                color: darkMode ? "#fff" : "#000",
              }}
            >
              Influencer Management System
            </Typography>
            <Switch checked={darkMode} onChange={() => setDarkMode(!darkMode)} />
          </Toolbar>
        </AppBar>

        <main
          style={{
            position: "relative",
            zIndex: 1, // ✅ sits above background
            padding: "24px",
            marginTop: "64px", // height of AppBar
            marginLeft: open ? drawerWidthOpen : drawerWidthClosed,
            width: `calc(100% - ${open ? drawerWidthOpen : drawerWidthClosed}px)`,
            transition: "margin-left 0.3s, width 0.3s",
          }}
        >
          {children}
        </main>
      </div>
    </div>
  );
};

export default SidebarLayout;
