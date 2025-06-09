import { StyleSheet } from "react-native";

import { colors } from "@/src/constants/colors";

export const styles = StyleSheet.create({
  button: {
    backgroundColor: colors.blueLazuli,
    paddingVertical: 14,
    paddingHorizontal: 20,
    borderRadius: 8,
    marginVertical: 5,
    marginHorizontal: 5,
    minWidth: 100,
    elevation: 4,
    shadowColor: '#000',
  },
  buttonText: {
    color: colors.whiteIce,
    fontWeight: "bold",
    fontSize: 18,
  },
})