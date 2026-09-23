import {
  Drawer,
  Box,
  IconButton,
  List,
  ListItemButton,
  ListItemText,
  Typography,
  Divider,
  Collapse,
  useTheme,
} from "@mui/material";
import CloseIcon from "@mui/icons-material/Close";
import MenuIcon from "@mui/icons-material/Menu";
import AddIcon from "@mui/icons-material/Add";
import { useState } from "react";
import { useNavigate } from "react-router";
import type { NavLink } from "../../shared/navLinks";
import AppLogoWithName from "../global/AppLogoWithName";
import TemporaryDrawerFooter from "./TemporaryDrawerFooter";

export default function TemporaryDrawer({ items }: { items: NavLink[] }) {
  const [open, setOpen] = useState(false);
  const [expanded, setExpanded] = useState<string | null>(null);
  const navigate = useNavigate();
  const theme = useTheme();

  const toggleDrawer = (next: boolean) => () => {
    setOpen(next);
    if (!next) setExpanded(null);
  };

  const go = (href?: string) => {
    if (href) navigate(href);
    setOpen(false);
    setExpanded(null);
  };

  return (
    <>
      <IconButton
        onClick={toggleDrawer(true)}
        aria-label="Open menu"
        disableRipple
        sx={{
          color: theme.palette.text.primary,
          borderRadius: 0,
          p: 1,
          "&:hover": {
            backgroundColor: theme.palette.action.hover,
            color: theme.palette.secondary.main,
          },
        }}
      >
        <MenuIcon />
      </IconButton>

      <Drawer
        anchor="right"
        open={open}
        onClose={toggleDrawer(false)}
        slotProps={{
          paper: {
            sx: {
              width: { xs: "100%", sm: 400 },
              backgroundColor: theme.palette.background.default,
              borderLeft: `1px solid ${theme.palette.divider}`,
            },
          },
          backdrop: {
            sx: {
              backgroundColor: "rgba(0, 0, 0, 0.5)",
              backdropFilter: "blur(6px)",
            },
          },
        }}
      >
        <Box
          sx={{
            display: "flex",
            flexDirection: "column",
            height: "100%",
            fontFamily: theme.typography.fontFamily,
          }}
        >
          <Box
            sx={{
              display: "flex",
              alignItems: "center",
              justifyContent: "space-between",
              px: 3,
              py: 3,
            }}
          >
            <AppLogoWithName />

            <IconButton
              onClick={toggleDrawer(false)}
              aria-label="Close menu"
              disableRipple
              size="small"
              sx={{
                color: theme.palette.text.primary,
                borderRadius: "50%",
                border: `1px solid ${theme.palette.divider}`,
                p: 0.75,
                transition: "border-color 200ms ease, color 200ms ease",
                "&:hover": {
                  borderColor: theme.palette.secondary.main,
                  color: theme.palette.secondary.main,
                },
              }}
            >
              <CloseIcon fontSize="small" />
            </IconButton>
          </Box>

          {/* Navigation List */}
          <List sx={{ py: 0, flex: 1, px: 0, overflowY: "auto" }}>
            {items.map((link, i) => {
              const isExpanded = expanded === link.label;

              return (
                <Box key={link.label}>
                  <ListItemButton
                    disableRipple
                    onClick={() =>
                      link.subItems
                        ? setExpanded(isExpanded ? null : link.label)
                        : go(link.href)
                    }
                    sx={{
                      px: 3,
                      py: 2.25,
                      position: "relative",
                      "&::before": {
                        content: '""',
                        position: "absolute",
                        left: 0,
                        top: 0,
                        bottom: 0,
                        width: 2,
                        backgroundColor: theme.palette.secondary.main,
                        transform: isExpanded ? "scaleY(1)" : "scaleY(0)",
                        transformOrigin: "top",
                        transition: "transform 250ms ease",
                      },
                      "&:hover": { backgroundColor: "transparent" },
                    }}
                  >
                    <ListItemText
                      primary={link.label}
                      slotProps={{
                        primary: {
                          sx: {
                            color: theme.palette.text.primary,
                            fontWeight: isExpanded ? 600 : 500,
                            fontSize: 22,
                            letterSpacing: "-0.01em",
                            transition: "font-weight 150ms ease",
                          },
                        },
                      }}
                    />
                    {link.subItems && (
                      <AddIcon
                        fontSize="small"
                        sx={{
                          color: theme.palette.text.secondary,
                          transition: "transform 250ms ease",
                          transform: isExpanded ? "rotate(135deg)" : "none",
                        }}
                      />
                    )}
                  </ListItemButton>

                  {link.subItems && (
                    <Collapse in={isExpanded} timeout={220} unmountOnExit>
                      <Box sx={{ pl: 3, pr: 3, pb: 3 }}>
                        {link.subItems.map((item, idx) =>
                          item.category ? (
                            <Box
                              key={item.category}
                              sx={{
                                display: "flex",
                                alignItems: "center",
                                gap: 1,
                                mt: idx === 0 ? 0 : 2.5,
                                mb: 1,
                                opacity: 0,
                                animation: "fadeIn 300ms ease forwards",
                                animationDelay: `${idx * 25}ms`,
                                "@keyframes fadeIn": { to: { opacity: 1 } },
                              }}
                            >
                              <Box
                                sx={{
                                  width: 10,
                                  height: 1,
                                  backgroundColor: theme.palette.secondary.main,
                                }}
                              />
                              <Typography
                                sx={{
                                  fontSize: 12,
                                  fontWeight: 600,
                                  color: theme.palette.text.secondary,
                                }}
                              >
                                {item.category}
                              </Typography>
                            </Box>
                          ) : (
                            <ListItemButton
                              key={item.label}
                              disableRipple
                              onClick={() => go(item.href)}
                              sx={{
                                px: 0,
                                py: 1,
                                borderRadius: 0,
                                opacity: 0,
                                animation: "fadeIn 300ms ease forwards",
                                animationDelay: `${idx * 25}ms`,
                                "@keyframes fadeIn": { to: { opacity: 1 } },
                                "&:hover": {
                                  backgroundColor: "transparent",
                                  "& .item-label": {
                                    color: theme.palette.secondary.main,
                                  },
                                },
                              }}
                            >
                              <ListItemText
                                primary={item.label}
                                secondary={item.description}
                                slotProps={{
                                  primary: {
                                    className: "item-label",
                                    sx: {
                                      fontSize: 15,
                                      fontWeight: 500,
                                      color: theme.palette.text.primary,
                                      transition: "color 150ms ease",
                                    },
                                  },
                                  secondary: {
                                    sx: {
                                      fontSize: 12.5,
                                      color: theme.palette.text.secondary,
                                      mt: 0.25,
                                    },
                                  },
                                }}
                              />
                            </ListItemButton>
                          ),
                        )}
                      </Box>
                    </Collapse>
                  )}

                  {i < items.length - 1 && (
                    <Divider sx={{ mx: 3, opacity: 0.6 }} />
                  )}
                </Box>
              );
            })}
          </List>

          {/* Footer */}
          <Box
            sx={{
              borderTop: `1px solid ${theme.palette.divider}`,
              px: 3,
              py: 2,
              mt: "auto",
            }}
          >
            <TemporaryDrawerFooter />
          </Box>
        </Box>
      </Drawer>
    </>
  );
}
