import { StyleSheet } from "react-native";

import { colors } from "@/src/constants/colors";

export const styles = StyleSheet.create({
  button: {
    backgroundColor: colors.blueDark,
    paddingVertical: 14,
    borderRadius: 8,
    alignItems: "center",
  },
  buttonText: {
    color: colors.whiteIce,
    fontWeight: "bold",
    fontSize: 18,
  },
})