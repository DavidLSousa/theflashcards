import { TouchableOpacity, Text, TouchableOpacityProps, StyleProp, ViewStyle } from "react-native";
import { styles } from "./styles";

type Props = TouchableOpacityProps & {
  title: string;
  style?: StyleProp<ViewStyle>;
};

export default function Button({ title, style, ...rest }: Props) {
  return (
    <TouchableOpacity style={[styles.button, style]} {...rest}>
      <Text style={styles.buttonText}>{title}</Text>
    </TouchableOpacity>
  );
}
