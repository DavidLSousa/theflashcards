import { StyleSheet } from "react-native"

import { colors } from "@/src/constants/colors";

export const styles = StyleSheet.create({
  container: {
    padding: 20,
    marginVertical: 10,
    borderRadius: 8,
    backgroundColor: colors.whiteIce,
  },
  category: {
    color: colors.blueLazuli,
  },
  quest: { 
    fontSize: 24, 
    alignSelf: "center",
    marginVertical: 10,
    color: colors.blueDark 
  },
  resp: {
    fontSize: 20,
    alignSelf: "center",
    marginVertical: 10,
    color: colors.blueDark,
  }
})