import { Box, Typography } from "@mui/material";

export default function TemporaryDrawerFooter() {
  return (
    <Box
      sx={{
        display: "flex",
        alignItems: "center",
        flexWrap: "wrap",
        gap: 0.5,
      }}
    >
      <Typography
        variant="caption"
        sx={{ whiteSpace: "nowrap", color: "text.secondary" }}
      >
        © {new Date().getFullYear()} Musicians SaaS. All rights reserved.
      </Typography>
    </Box>
  );
}
