import { StyleSheet } from "react-native";

import { colors } from "@/src/constants/colors";

export const styles = StyleSheet.create({
  inputSingle: {
    backgroundColor: colors.whiteIce,
    padding: 12,
    borderRadius: 8,
    color: colors.text,
  },
  inputMulti: {
    backgroundColor: colors.whiteIce,
    padding: 12,
    borderRadius: 8,
    height: 100,
    textAlignVertical: "top",
    color: colors.text,
  },
})