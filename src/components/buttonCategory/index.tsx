import { TouchableOpacity, Text, TouchableOpacityProps } from "react-native";

import { styles } from "./styles";

type Props = TouchableOpacityProps & {
  title: string;
};

export default function ButtonCategory({ title, ...rest }: Props) {
  return (
    <TouchableOpacity style={styles.button} {...rest}>
      <Text style={styles.buttonText}>{title}</Text>
    </TouchableOpacity>
  );
}