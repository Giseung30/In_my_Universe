# In my Universe
<div align="center">
  <a href="https://youtu.be/QH46O-MhlWc"> 
    <img width="30%" height="30%" src="https://user-images.githubusercontent.com/60832219/209007827-50c8e0df-2957-4191-91e5-34ab63bb7dd1.png"/>
  </a>
</div>

## 🖥 프로젝트 소개
+ 자신의 인간관계를 되돌아볼 수 있는 **성장형 SNS 애플리케이션**을 개발한다.
+ 오랫동안 함께 지낸 사람의 행성은 점차 풍요로운 형태를 갖추게 되는 시각적 요소를 가미한다.
  
## ⏲ 프로젝트 기간
- 2019.09~2019.12
- 소프트웨어 공학(전공 선택) : 팀 프로젝트
  
## 📣 프로젝트 계기
+ 현시점에서 많은 수익을 창출해낼 만한 소프트웨어를 구상하기 위해 프로젝트를 시작하게 되었다.
+ 강의를 한 학기 동안만 수행하기 때문에 시제품(Prototype) 정도로 개발을 목표로 삼았다.
  
## 📋 개발 과정
- 본인은 프론트 엔드 개발을 맡게 되었고, 나머지 구성원은 데이터베이스 설계, 3D 모델링, 기획 및 발표, 이미지 및 사운드 소스 제작을 맡았다.
- **개발 도구** : `Unity Engine`
- **데이터베이스** : `Json`
- **공통 글꼴** : `tvnmedium`
- **해상도** : `720 x 1280`
- **미디어 제작 도구**
  - 행성 및 우주비행사 오브젝트 : `Cinema 4D`
  - 우주 배경 및 UI : `일러스트레이터`
  - 사운드 : `Youtube`, `Goldwave`
- **스크립트**
  - 개수 : 12개
  - 주요 스크립트
    1. `Commander.cs` : 사용자와의 모든 상호작용을 담당하는 스크립트로써, 행성 오브젝트가 설치된 위치로 시점을 전환시키거나, 데이터베이스로부터 불러온 행성 정보에 맞게 행성을 배치하는 역할을 한다.
    2. `UIController.cs` : 모든 UI에서 발생한 Event를 받아 Commander 스크립트에 전달하는 역할을 하고, 화면이 전환될 때마다 행성의 이름, 레벨, 개수, 방문 날짜 등을 텍스트와 이미지로 표시한다.
    3. `DataBase.cs` : LitJson 플러그인을 읽어서 데이터베이스 파일이 존재하지 않으면 파일을 생성하고, 데이터베이스에서 값을 읽어오거나 새로운 행성 추가, 행성 삭제, 방문 일자 등록 등의 DB 갱신을 담당한다. 또한, 안드로이드의 데이터베이스 경로를 PC와 동일하게 설정한다.
- **설계도**
<div align="center">
  <img width="75%" height="75%" src="https://user-images.githubusercontent.com/60832219/209004774-b86de5c5-794e-41ca-ac6c-232c78c747c7.png"/>
</div>
    
## ✔ 프로젝트 평가
+ 많은 인원이 함께 수행하는 프로젝트였기 때문에 의사소통이 매우 중요했으나, 개발 초기에 기획한 내용을 잘못 이해해서 시간을 꽤 허비했었다. 이후, 매일 팀원들과 개발 점검하며 동일한 사건이 발생하지 않도록 노력했다. 본 과제는 기존에 몰랐던 기법들을 학습하는 계기가 되었을 뿐만 아니라 **의사소통의 중요성**도 깨닫게 해주었다.
+ 주어진 기간 내에 시제품을 만들어내는 데에 성공했고, 시연을 무사히 마무리했다. 담당 교수님께서는 시제품 완성도를 굉장히 높게 평가해주셨으며, 본 강의는 A+였다.
+ 프로젝트의 기여도를 스스로 평가하자면 **30**%이다. 팀장으로써 구성원들의 역할을 분담하고, 프로젝트 변경 사항을 최종적으로 적용하면서 잘 이끌었다고 생각한다.

## 📷 스크린샷
<div align="center">
  <img width="30%" height="30%" src="https://user-images.githubusercontent.com/60832219/209004482-cf3cad57-bebe-48b6-935c-6532d75e30b8.png"/>
  <img width="30%" height="30%" src="https://user-images.githubusercontent.com/60832219/209004487-33096dc3-d22c-4b11-b0e6-cfd8281bd542.png"/>
  <img width="30%" height="30%" src="https://user-images.githubusercontent.com/60832219/209004491-bb345327-b187-4efd-9fbf-d8b07fe4544e.png"/>
  <img width="30%" height="30%" src="https://user-images.githubusercontent.com/60832219/209004493-5a6a1797-929a-400d-afc0-aa380cc50a1c.png"/>
  <img width="30%" height="30%" src="https://user-images.githubusercontent.com/60832219/209004494-30184dff-9e3e-4ee9-bd20-c27c12bdfcf5.png"/>
  <img width="30%" height="30%" src="https://user-images.githubusercontent.com/60832219/209004496-6012de3c-5a20-4863-bf79-c1a79e88a104.png"/>
</div>
