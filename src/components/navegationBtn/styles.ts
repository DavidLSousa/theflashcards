import { StyleSheet } from "react-native";

import { colors } from "@/src/constants/colors";

export const styles = StyleSheet.create({
  button: {
    backgroundColor: colors.whiteIce,
    alignItems: "center",
    padding: 15,
    marginHorizontal: 30,
    marginVertical: 10,
    borderRadius: 8,
    overflow: "hidden",
    elevation: 4,
    shadowColor: '#000',
  },
  buttonText: {
    color: colors.blueMedium,
    fontSize: 20,
  }
})
