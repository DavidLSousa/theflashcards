import { TextInput, TextInputProps } from "react-native";
import { styles } from "./styles";

type Props = TextInputProps & {
  value: string;
  onChangeText: (text: string) => void;
};

export default function Input({ value, onChangeText, ...rest }: Props) {
  return (
    <TextInput
      style={rest.multiline ? styles.inputMulti : styles.inputSingle}
      placeholderTextColor="#ccc"
      value={value}
      onChangeText={onChangeText}
      {...rest}
    />
  );
}