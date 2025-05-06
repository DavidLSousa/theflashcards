import { StyleSheet } from "react-native";

import { colors } from "@/src/constants/colors";

export const styles = StyleSheet.create({
  button: {
    backgroundColor: colors.whiteIce,
    alignItems: "center",
    padding: 10,
    margin: 10,
    borderRadius: 8,
    overflow: "hidden",
  },
  buttonText: {
    color: colors.blueMedium,
    fontSize: 20,
  }
})
