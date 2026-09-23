import {
  Box,
  Menu,
  Stack,
  Typography,
  Button,
  useTheme,
  useMediaQuery,
} from "@mui/material";
import { Link as RouterLink } from "react-router";
import KeyboardArrowDownIcon from "@mui/icons-material/KeyboardArrowDown";
import { useState } from "react";

interface MenuItem {
  label?: string;
  href?: string;
  category?: string;
  description?: string;
}

function groupByCategory(items: MenuItem[]) {
  const groups: Record<string, MenuItem[]> = {};
  let current = "";
  for (const item of items) {
    if (item.category) {
      current = item.category;
      groups[current] = [];
    } else groups[current]?.push(item);
  }
  return groups;
}

export default function NavDropdownMenu({
  label,
  items,
}: {
  label: string;
  items: MenuItem[];
}) {
  const theme = useTheme();
  const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null);
  const isMobile = useMediaQuery(theme.breakpoints.down("md"));

  const open = Boolean(anchorEl) && !isMobile;
  const close = () => setAnchorEl(null);

  const columnCount = label === "Product" ? 4 : 3;

  return (
    <Box>
      <Button
        onClick={(e) => setAnchorEl(e.currentTarget)}
        endIcon={
          <KeyboardArrowDownIcon
            sx={{
              fontSize: "1.1rem",
              transition: "transform 250ms ease",
              transform: open ? "rotate(180deg)" : "none",
            }}
          />
        }
        sx={{
          color: theme.palette.text.primary,
          fontWeight: 600,
          fontSize: 13,
          letterSpacing: "0.15em",
          textTransform: "uppercase",
          p: 0,
          minWidth: "auto",
          gap: 0.75,
          "&:hover": {
            backgroundColor: "transparent",
            color: theme.palette.secondary.main,
          },
        }}
      >
        {label}
      </Button>

      <Menu
        anchorEl={anchorEl}
        open={open}
        onClose={close}
        transformOrigin={{ horizontal: "center", vertical: "top" }}
        anchorOrigin={{ horizontal: "center", vertical: "bottom" }}
        slotProps={{
          paper: {
            elevation: 0,
            sx: {
              backgroundColor: theme.palette.background.paper,
              border: `1px solid ${theme.palette.divider}`,
              mt: 1.5,
              width: "auto",
              maxWidth: "calc(100vw - 32px)",
              maxHeight: "calc(100vh - 120px)",
              overflowY: "auto",
              boxShadow: "0 12px 48px rgba(0,0,0,0.15)",
            },
          },
        }}
      >
        <Box
          sx={{
            p: 3,
            display: "grid",
            gridTemplateColumns: `repeat(${columnCount}, minmax(160px, 1fr))`,
            gap: 3,
          }}
        >
          {Object.entries(groupByCategory(items)).map(([cat, catItems]) => (
            <Box key={cat}>
              <Typography
                sx={{
                  fontSize: 11,
                  letterSpacing: "0.15em",
                  textTransform: "uppercase",
                  fontWeight: 700,
                  color: theme.palette.secondary.main,
                  mb: 2,
                }}
              >
                {cat}
              </Typography>
              <Stack spacing={1}>
                {catItems.map((item) => (
                  <Box
                    key={item.label}
                    component={RouterLink}
                    to={item.href || "#"}
                    onClick={close}
                    sx={{
                      display: "flex",
                      flexDirection: "column",
                      gap: 0.25,
                      p: 1.5,
                      color: theme.palette.text.primary,
                      textDecoration: "none",
                      borderLeft: "3px solid transparent",
                      transition: "all 150ms ease",
                      "&:hover": {
                        backgroundColor: theme.palette.action.hover,
                        borderLeft: `3px solid ${theme.palette.secondary.main}`,
                        pl: 2,
                        color: theme.palette.secondary.main,
                      },
                    }}
                  >
                    <Typography
                      sx={{
                        fontSize: 13,
                        fontWeight: 600,
                        letterSpacing: "0.08em",
                      }}
                    >
                      {item.label}
                    </Typography>
                    {item.description && (
                      <Typography
                        sx={{
                          fontSize: 11,
                          color: theme.palette.text.secondary,
                        }}
                      >
                        {item.description}
                      </Typography>
                    )}
                  </Box>
                ))}
              </Stack>
            </Box>
          ))}
        </Box>
      </Menu>
    </Box>
  );
}
