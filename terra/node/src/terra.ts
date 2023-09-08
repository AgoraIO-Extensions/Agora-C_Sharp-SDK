// declare global {
export enum CXXTYPE {
  Unknown = 'Unknown',
  CXXFile = 'CXXFile',
  IncludeDirective = 'IncludeDirective',
  TypeAlias = 'TypeAlias',
  Clazz = 'Clazz',
  Struct = 'Struct',
  Constructor = 'Constructor',
  MemberFunction = 'MemberFunction',
  Variable = 'Variable',
  SimpleType = 'SimpleType',
  MemberVariable = 'MemberVariable',
  EnumConstant = 'EnumConstant',
  Enumz = 'Enumz',
}

export abstract class TerraNode {
  __TYPE: CXXTYPE;
  name: string;
  file_path: string;
  namespaces: string[];
  parent_name: string;
  attributes: string[];
  comment: string;
  source: string;
  user_data?: any;
}

export interface TerraNode {
  asCXXFile(): CXXFile;

  asIncludeDirective(): IncludeDirective;

  asTypeAlias(): TypeAlias;

  asClazz(): Clazz;

  asStruct(): Struct;

  asConstructor(): Constructor;

  asMemberFunction(): MemberFunction;

  asVariable(): Variable;

  asSimpleType(): SimpleType;

  asMemberVariable(): MemberVariable;

  asEnumConstant(): EnumConstant;

  asEnumz(): Enumz;
}

export interface TerraNode {
  /**
   * Returns the name of the TerraNode, including any namespaces.
   */
  nameWithNamespace(): string;

  /**
   * Returns the name of this node without the namespace
   */
  nameWithoutNamespace(): string;

  /**
   * Return the namespaces in string format
   * @return {string} The namespaces in string format
   */
  getNamespacesInString(): string;
}

export class IncludeDirective extends TerraNode {
  __TYPE: CXXTYPE;
  include_file_path: string;
}

export class TypeAlias extends TerraNode {
  __TYPE: CXXTYPE;
  underlyingType: SimpleType;
}

export class Constructor extends TerraNode {
  __TYPE: CXXTYPE;
  parameters: Variable[];
}

export class Clazz extends TerraNode {
  __TYPE: CXXTYPE;
  constructors: Constructor[];
  methods: MemberFunction[];
  member_variables: MemberVariable[];
  base_clazzs: string[];
}

export interface Clazz {
  /**
   * Returns the base classes of this class
   * @return {Clazz[]} The base classes of this class
   */
  findBaseClazzs(cxxfiles: CXXFile[]): Clazz[];
}

export class Struct extends Clazz {
  __TYPE: CXXTYPE;
}

export class Enumz extends TerraNode {
  __TYPE: CXXTYPE;
  enum_constants: EnumConstant[];
}

export class MemberFunction extends TerraNode {
  __TYPE: CXXTYPE;
  is_virtual: boolean;
  return_type: SimpleType;
  parameters: Variable[];
  access_specifier: string;
  is_overriding: boolean;
  is_const: boolean;
  signature: string;
}

export class Variable extends TerraNode {
  __TYPE: CXXTYPE;
  type: SimpleType;
  default_value: string;
  is_output: boolean;
}

export enum SimpleTypeKind {
  value_t = 100,
  pointer_t = 101,
  reference_t = 102,
  array_t = 103,
}

export class SimpleType extends TerraNode {
  __TYPE: CXXTYPE;
  kind: SimpleTypeKind;
  is_const: boolean;
  is_builtin_type: boolean;
}

export interface SimpleType {
  /**
   * This code returns a type name that is either the name of the type, or the source of the type.
   */
  getTypeName(): string;
}

export class MemberVariable extends TerraNode {
  __TYPE: CXXTYPE;
  type: SimpleType;
  is_mutable: boolean;
  access_specifier: string;
}

export class EnumConstant extends TerraNode {
  __TYPE: CXXTYPE;
  value: string;
}

export class CXXFile extends TerraNode {
  __TYPE: CXXTYPE;
  nodes: TerraNode[];
}

export interface MustacheRenderConfiguration {
  fileNameTemplatePath: string;
  fileContentTemplatePath: string;
  view: any;
  // default: baseDir at fileContentTemplate
  childrenTemplatesPath?: string;
  // default: '.mustache'
  templateFilePostfix?: string;
}

export interface MustacheRenderContext {
  renderWithConfiguration(
    config: MustacheRenderConfiguration
  ): RenderResult[];

  renderWithTemplate(
    template: string,
    view: any,
    childrenTemplates?: Record<string, string>
  ): string;
}

export interface RenderContext {
  getAllClazzs(cxxfiles: CXXFile[]): Clazz[];

  getAllEnums(cxxfiles: CXXFile[]): Enumz[];

  getAllStructs(cxxfiles: CXXFile[]): Struct[];

  mustacheRenderContext: MustacheRenderContext;
}

export interface RenderResult {
  file_name: string;
  file_content: string;
}

export var render: (
  cxxFiles: CXXFile[],
  context: RenderContext
) => RenderResult[];
// }

// export { };
